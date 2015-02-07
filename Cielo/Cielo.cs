using Cielo.Helpers;
using Cielo.Messages;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cielo
{
    public class Cielo : ICielo
    {
        private readonly CieloConfig _config;

        public Cielo()
        {
            _config = ConfigurationManager.GetSection("cielo") as CieloConfig;
        }

        public Cielo(CieloConfig config)
        {
            _config = config;
        }

        public async Task<Retorno> Autorizacao(RequisicaoTransacao requisicaoTransacao)
        {
            if (requisicaoTransacao.DadosEc == null)
            {
                requisicaoTransacao.DadosEc = new DadosEc { Chave = _config.Chave, Numero = _config.Numero };
            }

            return await SendMessage(requisicaoTransacao);
        }

        public async Task<Retorno> Autorizacao(RequisicaoAutorizacaoTid requisacaoAutorizacaoTid)
        {
            return await SendMessage(requisacaoAutorizacaoTid);
        }

        public async Task<Retorno> RenovaFacil()
        {
            throw new NotImplementedException();
        }

        public async Task<Retorno> GeracaoToken(RequisicaoToken requisicaoToken)
        {
            return await SendMessage(requisicaoToken);
        }

        public async Task<Retorno> Captura(RequisicaoCaptura requisicaoCaptura)
        {
            return await SendMessage(requisicaoCaptura);
        }

        public async Task<Retorno> Consulta(RequisicaoConsulta requisicaoConsulta)
        {
            return await SendMessage(requisicaoConsulta);
        }

        public async Task<Retorno> Consulta(RequisicaoConsultaChSec requisicaoConsultaChSec)
        {
            return await SendMessage(requisicaoConsultaChSec);
        }

        public async Task<Retorno> Cancelamento(RequisicaoCancelamento requisicaoCancelamento)
        {
            return await SendMessage(requisicaoCancelamento);
        }

        public async Task<Retorno> Cancelamento(RequisicaoCancelamentoParcial requisicaoCancelamentoParcial)
        {
            return await SendMessage(requisicaoCancelamentoParcial);
        }

        private async Task<Retorno> SendMessage<T>(T mensagem)
        {
            var encoding = Encoding.GetEncoding("ISO-8859-1");

            var xml = mensagem.ToXml<T>(encoding);

            var contentPayload = new StringContent(string.Format("mensagem={0}", xml), encoding, "application/x-www-form-urlencoded");

            var response = await new HttpClient().PostAsync(_config.Endpoint.AbsoluteUri, contentPayload);

            if (response.IsSuccessStatusCode)
            {
                var responseXml = await response.Content.ReadAsStringAsync();

                return new Retorno(responseXml);
            }

            return null;
        }
    }
}
