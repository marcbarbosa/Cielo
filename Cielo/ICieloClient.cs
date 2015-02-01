using Cielo.Messages;
using System.Threading.Tasks;

namespace Cielo
{
    public interface ICieloClient
    {
        Task<Retorno> Autorizacao(RequisicaoTransacao requisicaoTransacao);

        Task<Retorno> Autorizacao(RequisicaoAutorizacaoTid requisacaoAutorizacaoTid);

        Task<Retorno> RenovaFacil();

        Task<Retorno> GeracaoToken(RequisicaoToken requisicaoToken);

        Task<Retorno> Captura(RequisicaoCaptura requisicaoCaptura);

        Task<Retorno> Consulta(RequisicaoConsulta requisicaoConsulta);

        Task<Retorno> Consulta(RequisicaoConsultaChSec requisicaoConsultaChSec);

        Task<Retorno> Cancelamento(RequisicaoCancelamento requisicaoCancelamento);

        Task<Retorno> Cancelamento(RequisicaoCancelamentoParcial requisicaoCancelamentoParcial);
    }
}
