using Cielo.Messages;
using System;
using System.Threading.Tasks;

namespace Cielo
{
    public interface ICieloClient
    {
        Task<Retorno> AutorizarTransacao(string tid);
        
        Task<Retorno> CancelarTransacao(string tid);
        
        Task<Retorno> CapturarTransacao(string tid);
        
        Task<Retorno> CapturarTransacao(string tid, decimal valor, string anexo);
        
        Task<Retorno> ConsultarTransacao(string tid);
        
        Task<Retorno> CriarTransacao(DadosPedido dadosPedido, DadosEcAutenticacao dadosEc, FormaPagamento formaPagamento, Uri urlRetorno, RequisicaoTransacaoAutorizar reqAutorizar, bool capturar);
        
        Task<Retorno> CriarTransacao(DadosPedido dadosPedido, FormaPagamentoBandeira bandeira, Uri urlRetorno);
    }
}
