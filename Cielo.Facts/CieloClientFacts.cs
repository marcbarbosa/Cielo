using Cielo.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cielo.Facts
{
    public class CieloClientFacts
    {
        public class Constructor
        {
            [Fact]
            public void ShoudReturnArgumentNullExceptionGivenNoConfigSettings()
            {
                // arrange
                // act
                //assert
                Assert.Throws<ArgumentNullException>(() => new CieloClient());
            }
        }

        public class AutorizarTransacao
        {
            [Fact]
            public void ShouldReturnNullGivenNullTid()
            {
                // arrange
                var cielo = new CieloClient();
                var requisicaoToken = new RequisicaoToken
                {
                    id = DateTime.Now.Millisecond.ToString(),
                    dadosec = new DadosEc 
                    {
                        chave = "25fbb99741c739dd84d7b06ec78c9bac718838630f30b112d033ce2e621b34f3",
                        numero = "1006993069" 
                    },
                    dadosPortador = new DadosPortador 
                    {
                        numero = "4012001037141112",
                        validade = "201805",
                        codigoseguranca = "123",
                        indicador = DadosCartaoIndicador.Informado
                    },
                    versao = MensagemVersao.v140
                };

                // act
                var actual = cielo.GeracaoToken(requisicaoToken).Result;

                //assert
                Assert.True(actual.IsToken());
            }
        }
    }
}
