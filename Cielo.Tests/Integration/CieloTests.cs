using Cielo.Messages;
using System;
using Xunit;

namespace Cielo.Tests.Integration
{
    public class CieloTests
    {
        public class GeracaoToken
        {
            private readonly RequisicaoToken defaultRequisicaoToken;

            public GeracaoToken()
            {
                defaultRequisicaoToken = new RequisicaoToken
                {
                    Id = DateTime.Now.Millisecond.ToString(),
                    DadosEc = new DadosEc
                    {
                        Chave = "25fbb99741c739dd84d7b06ec78c9bac718838630f30b112d033ce2e621b34f3",
                        Numero = "1006993069"
                    },
                    dadosPortador = new DadosPortador
                    {
                        Numero = "4012001037141112",
                        Validade = "201805",
                        CodigoSeguranca = "123",
                        Indicador = DadosCartaoIndicador.Informado
                    },
                    Versao = MensagemVersao.v140
                };
            }

            [Fact]
            public void ReturnsCorrectDadosToken()
            {
                // arrange
                var expectedDadosToken = new DadosToken
                {
                    codigotoken = "HYcQ0MQ39fl8kn9OR7lFsTtxa+wNuM4lqQLUeN5SYZY=",
                    numerocartaotruncado = "211141******2104",
                    status = TokenStatus.Desbloqueado
                };

                var cielo = new Cielo();

                // act
                var actualResponse = cielo.GeracaoToken(defaultRequisicaoToken).Result;
                var actualDadosToken = actualResponse.Token.token.dadostoken;

                //assert
                Assert.True(actualResponse.IsToken);
                Assert.Equal(expectedDadosToken.codigotoken, actualDadosToken.codigotoken);
                Assert.Equal(expectedDadosToken.numerocartaotruncado, actualDadosToken.numerocartaotruncado);
                Assert.Equal(expectedDadosToken.status, actualDadosToken.status);
            }
        }

        public class Autorizacao
        {
            private readonly RequisicaoTransacao _defaultRequisicaoTransacao;

            public Autorizacao()
            {
                _defaultRequisicaoTransacao = new RequisicaoTransacao
                {
                    Id = DateTime.Now.Millisecond.ToString(),
                    DadosPedido = new DadosPedido
                    {
                        Numero = DateTime.Now.Millisecond.ToString(),
                        Valor = 100,
                        Moeda = Moeda.Real,
                        DataHora = DateTime.Now
                    },
                    FormaPagamento = new FormaPagamento
                    {
                        Bandeira = FormaPagamentoBandeira.Visa,
                        BandeiraSpecified = true,
                        Produto = FormaPagamentoProduto.CreditoAVista,
                        Parcelas = 1
                    },
                    Autorizar = RequisicaoTransacaoAutorizar.AutorizarSemPassarPorAutenticacao,
                    Capturar = true,
                    Versao = MensagemVersao.v140
                };
            }

            [Fact]
            public void WithCreditCardReturnsTransacao()
            {
                // arrange
                var cielo = new Cielo();

                _defaultRequisicaoTransacao.DadosPortador = new DadosPortador
                {
                    Numero = "4012001037141112",
                    Validade = "201805",
                    CodigoSeguranca = "123",
                    Indicador = DadosCartaoIndicador.Informado
                };

                // act
                var actual = cielo.Autorizacao(_defaultRequisicaoTransacao).Result;

                if (!actual.IsTransacao)
                {
                    throw new Exception(actual.RawXml);
                }

                //assert
                Assert.True(actual.IsTransacao);
                Assert.Equal(actual.Transacao.Status, Status.Capturada);
            }
        }
    }
}
