using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Cielo.Messages;
using Cielo.Helpers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Cielo
{
    public class CieloClient : ICieloClient
    {
        private string Numero;
        private string Chave;
        private Uri Endpoint;

        public CieloClient()
        {
            if (ConfigurationManager.AppSettings["Cielo.Numero"] == null)
                throw new ArgumentNullException("Cielo.Numero");

            if (ConfigurationManager.AppSettings["Cielo.Chave"] == null)
                throw new ArgumentNullException("Cielo.Chave");

            if (ConfigurationManager.AppSettings["Cielo.Ambiente"] == null)
                throw new ArgumentNullException("Cielo.Ambientes");

            Numero = ConfigurationManager.AppSettings["Cielo.Numero"];
            Chave = ConfigurationManager.AppSettings["Cielo.Chave"];

            if (ConfigurationManager.AppSettings["Cielo.Ambiente"].Equals("Producao"))
                Endpoint = new Uri(ConfigurationManager.AppSettings["Cielo.UrlProducao"]);
            else
                Endpoint = new Uri(ConfigurationManager.AppSettings["Cielo.UrlTeste"]);
        }

        public async Task<Retorno> CriarTransacao(DadosPedido dadosPedido, FormaPagamentoBandeira bandeira, Uri urlRetorno)
        {
            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };
            var formaPagamento = new FormaPagamento { bandeira = bandeira, parcelas = 1, produto = FormaPagamentoProduto.CreditoAVista };
            var req = RequisicaoNovaTransacaoAutorizar.AutorizarAutenticadaENaoAutenticada;
            var capturar = true;

            return await CriarTransacao(dadosPedido, dadosEc, formaPagamento, urlRetorno, req, capturar);
        }

        public async Task<Retorno> CriarTransacao(DadosPedido dadosPedido, DadosEcAutenticacao dadosEc, FormaPagamento formaPagamento,
                                      Uri urlRetorno, RequisicaoNovaTransacaoAutorizar reqAutorizar, bool capturar)
        {
            var msg = new RequisicaoNovaTransacao
            {
                id = dadosPedido.numero,
                versao = MensagemVersao.v140,
                dadosec = dadosEc,
                dadospedido = dadosPedido,
                formapagamento = formaPagamento,
                urlretorno = urlRetorno.AbsoluteUri,
                autorizar = reqAutorizar,
                capturar = capturar
            };

            var xml = msg.ToXml<RequisicaoNovaTransacao>(Encoding.GetEncoding("iso-8859-1"));

            return await EnviarMensagem(xml);
        }

        public async Task<Retorno> ConsultarTransacao(string tid)
        {
            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };

            var msg = new RequisicaoConsulta
            {
                id = DateTime.Now.ToString("yyyyMMdd"),
                versao = MensagemVersao.v140,
                tid = tid,
                dadosec = dadosEc
            };

            var xml = msg.ToXml<RequisicaoConsulta>(Encoding.GetEncoding("iso-8859-1"));

            return await EnviarMensagem(xml);
        }

        public async Task<Retorno> AutorizarTransacao(string tid)
        {
            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };

            var msg = new RequisicaoAutorizacaoTid
            {
                id = DateTime.Now.ToString("yyyyMMdd"),
                versao = MensagemVersao.v140,
                tid = tid,
                dadosec = dadosEc
            };

            var xml = msg.ToXml<RequisicaoAutorizacaoTid>(Encoding.GetEncoding("iso-8859-1"));

            return await EnviarMensagem(xml);
        }

        public async Task<Retorno> CancelarTransacao(string tid)
        {
            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };

            var msg = new RequisicaoCancelamento
            {
                id = DateTime.Now.ToString("yyyyMMdd"),
                versao = MensagemVersao.v140,
                tid = tid,
                dadosec = dadosEc
            };

            var xml = msg.ToXml<RequisicaoCancelamento>(Encoding.GetEncoding("iso-8859-1"));

            return await EnviarMensagem(xml);
        }

        public async Task<Retorno> CapturarTransacao(string tid)
        {
            return await CapturarTransacao(tid, -1, string.Empty);
        }

        public async Task<Retorno> CapturarTransacao(string tid, decimal valor, string anexo)
        {
            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };

            var msg = new RequisicaoCaptura
            {
                id = DateTime.Now.ToString("yyyyMMdd"),
                versao = MensagemVersao.v140,
                tid = tid,
                dadosec = dadosEc
            };

            if (valor > -1)
                msg.valor = valor.ToFormatoCielo();

            if (!string.IsNullOrWhiteSpace(anexo))
                msg.anexo = anexo;

            var xml = msg.ToXml<RequisicaoCaptura>(Encoding.GetEncoding("iso-8859-1"));

            return await EnviarMensagem(xml);
        }

        private Retorno XmlToRetorno(string xml)
        {
            var ret = new Retorno(xml);

            if (!string.IsNullOrEmpty(xml))
            {
                RetornoTransacao transacao;
                RetornoErro erro;

                if (xml.Contains("</transacao>"))
                {
                    transacao = xml.ToType<RetornoTransacao>(Encoding.GetEncoding("iso-8859-1"));
                    ret.Transacao = transacao;
                }
                else if (xml.Contains("</erro>"))
                {
                    erro = xml.ToType<RetornoErro>(Encoding.GetEncoding("iso-8859-1"));
                    ret.Erro = erro;
                }
            }

            return ret;
        }

        private async Task<Retorno> EnviarMensagem(string xml)
        {
            var contentPayload = new StringContent(string.Format("mensagem={0}", xml), Encoding.GetEncoding("iso-8859-1"), "application/x-www-form-urlencoded");

            var response = await new HttpClient().PostAsync(Endpoint.AbsoluteUri, contentPayload);

            if (response.IsSuccessStatusCode)
            {
                var responseXml = await response.Content.ReadAsStringAsync();

                return XmlToRetorno(responseXml);
            }

            return null;
        }
    }
}
