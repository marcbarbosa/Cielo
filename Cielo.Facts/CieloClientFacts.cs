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
            [Fact(Skip="Refactoring...")]
            public void ShouldReturnNullGivenNullTid()
            { 
                // arrange
                var cielo = new CieloClient();

                // act
                var actual = cielo.AutorizarTransacao(null);

                //assert
                Assert.Null(actual);
            }
        }
    }
}
