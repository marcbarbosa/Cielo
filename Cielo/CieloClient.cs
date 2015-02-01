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

        public async Task<Retorno> Autorizacao(RequisicaoTransacao requisicaoTransacao)
        {
            return await EnviarMensagem(requisicaoTransacao);
        }

        public async Task<Retorno> Autorizacao(RequisicaoAutorizacaoTid requisacaoAutorizacaoTid)
        {
            return await EnviarMensagem(requisacaoAutorizacaoTid);
        }

        public async Task<Retorno> RenovaFacil()
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno> GeracaoToken(RequisicaoToken requisicaoToken)
        {
            return await EnviarMensagem(requisicaoToken);
        }

        public async Task<Retorno> Captura(RequisicaoCaptura requisicaoCaptura)
        {
            return await EnviarMensagem<RequisicaoCaptura>(requisicaoCaptura);
        }

        public async Task<Retorno> Consulta(RequisicaoConsulta requisicaoConsulta)
        {
            return await EnviarMensagem(requisicaoConsulta);
        }

        public async Task<Retorno> Consulta(RequisicaoConsultaChSec requisicaoConsultaChSec)
        {
            return await EnviarMensagem(requisicaoConsultaChSec);
        }

        public async Task<Retorno> Cancelamento(RequisicaoCancelamento requisicaoCancelamento)
        {
            return await EnviarMensagem(requisicaoCancelamento);
        }

        public async Task<Retorno> Cancelamento(RequisicaoCancelamentoParcial requisicaoCancelamentoParcial)
        {
            return await EnviarMensagem(requisicaoCancelamentoParcial);
        }
        
        
        private Retorno XmlToRetorno(string xml)
        {
            var ret = new Retorno(xml);

            if (!string.IsNullOrEmpty(xml))
            {
                RetornoTransacao transacao;
                RetornoErro erro;
                RetornoToken token;

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
                else if (xml.Contains("</retorno-token>"))
                {
                    token = xml.ToType<RetornoToken>(Encoding.GetEncoding("iso-8859-1"));
                    ret.Token = token;
                }
            }

            return ret;
        }

        private async Task<Retorno> EnviarMensagem<T>(T mensagem)
        {
            var encoding = Encoding.GetEncoding("ISO-8859-1");

            var xml = mensagem.ToXml<T>(encoding);

            var contentPayload = new StringContent(string.Format("mensagem={0}", xml), encoding, "application/x-www-form-urlencoded");

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
