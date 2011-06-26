using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Cielo.Messages;
using Cielo.Helpers;

namespace Cielo
{
    public class CieloClient
    {
        #region "Private"

        private string Numero;
        private string Chave;
        private Uri Endpoint;

        #endregion

        #region "Constructor"

        public CieloClient()
        {
            Numero = ConfigurationManager.AppSettings["Cielo.Numero"];
            Chave = ConfigurationManager.AppSettings["Cielo.Chave"];

            if (ConfigurationManager.AppSettings["Cielo.Ambiente"].Equals("Producao"))
                Endpoint = new Uri(ConfigurationManager.AppSettings["Cielo.UrlProducao"]);
            else
                Endpoint = new Uri(ConfigurationManager.AppSettings["Cielo.UrlTeste"]);
        }

        #endregion

        #region "Public Methods"

        public Retorno CriarTransacao(DadosPedido dadosPedido, Bandeira bandeira, Uri urlRetorno)
        {
            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };
            var formaPagamento = new FormaPagamento { bandeira = bandeira, parcelas = 1, produto = FormaPagamentoProduto.CreditoAVista };
            var req = RequisicaoNovaTransacaoAutorizar.AutorizarAutenticadaENaoAutenticada;
            var capturar = true;

            return CriarTransacao(dadosPedido, dadosEc, formaPagamento, urlRetorno, req, capturar);
        }

        public Retorno CriarTransacao(DadosPedido dadosPedido, DadosEcAutenticacao dadosEc, FormaPagamento formaPagamento,
                                      Uri urlRetorno, RequisicaoNovaTransacaoAutorizar reqAutorizar, bool capturar)
        {
            var ret = new Retorno();

            var msg = new RequisicaoNovaTransacao
            {
                id = dadosPedido.numero,
                versao = MensagemVersao.v110,
                dadosec = dadosEc,
                dadospedido = dadosPedido,
                formapagamento = formaPagamento,
                urlretorno = urlRetorno.AbsoluteUri,
                autorizar = reqAutorizar,
                capturar = capturar
            };

            try
            {
                var xml = msg.ToXml<RequisicaoNovaTransacao>(Encoding.GetEncoding("iso-8859-1"));

                var res = EnviarMensagem(xml);

                ret = XmlToRetorno(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public Retorno ConsultarTransacao(string tid)
        {
            var ret = new Retorno();

            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };

            var msg = new RequisicaoConsulta
            {
                id = DateTime.Now.ToString("yyyyMMdd"),
                versao = MensagemVersao.v110,
                tid = tid,
                dadosec = dadosEc
            };

            try
            {
                var xml = msg.ToXml<RequisicaoConsulta>(Encoding.GetEncoding("iso-8859-1"));

                var res = EnviarMensagem(xml);

                ret = XmlToRetorno(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public Retorno AutorizarTransacao(string tid)
        {
            var ret = new Retorno();

            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };

            var msg = new RequisicaoAutorizacaoTid
            {
                id = DateTime.Now.ToString("yyyyMMdd"),
                versao = MensagemVersao.v110,
                tid = tid,
                dadosec = dadosEc
            };

            try
            {
                var xml = msg.ToXml<RequisicaoAutorizacaoTid>(Encoding.GetEncoding("iso-8859-1"));

                var res = EnviarMensagem(xml);

                ret = XmlToRetorno(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public Retorno CapturarTransacao(string tid)
        {
            var ret = new Retorno();

            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };

            var msg = new RequisicaoCaptura
            {
                id = DateTime.Now.ToString("yyyyMMdd"),
                versao = MensagemVersao.v110,
                tid = tid,
                dadosec = dadosEc
            };

            try
            {
                var xml = msg.ToXml<RequisicaoCaptura>(Encoding.GetEncoding("iso-8859-1"));

                var res = EnviarMensagem(xml);

                ret = XmlToRetorno(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        public Retorno CancelarTransacao(string tid)
        {
            var ret = new Retorno();

            var dadosEc = new DadosEcAutenticacao { numero = Numero, chave = Chave };

            var msg = new RequisicaoCancelamento
            {
                id = DateTime.Now.ToString("yyyyMMdd"),
                versao = MensagemVersao.v110,
                tid = tid,
                dadosec = dadosEc
            };

            try
            {
                var xml = msg.ToXml<RequisicaoCancelamento>(Encoding.GetEncoding("iso-8859-1"));

                var res = EnviarMensagem(xml);

                ret = XmlToRetorno(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        #endregion

        #region "Private Methods"

        private Retorno XmlToRetorno(string xml)
        {
            var ret = new Retorno();

            if (!string.IsNullOrEmpty(xml))
            {
                RetornoTransacao transacao;
                RetornoErro erro;

                if (xml.Contains("</transacao>"))
                {
                    transacao = xml.ToType<RetornoTransacao>(Encoding.GetEncoding("iso-8859-1"));
                    ret.Transacao = transacao;
                    ret.Transacao.rawXml = xml;
                }
                else if (xml.Contains("</erro>"))
                {
                    erro = xml.ToType<RetornoErro>(Encoding.GetEncoding("iso-8859-1"));
                    ret.Erro = erro;
                }
            }

            return ret;
        }

        private string EnviarMensagem(string xml)
        {
            var http = new EasyHttpClient("iso-8859-1", "application/x-www-form-urlencoded", "CieloClient");
            
            return http.Post(Endpoint.AbsoluteUri, string.Format("mensagem={0}", xml));
        }

        #endregion
    }
}
