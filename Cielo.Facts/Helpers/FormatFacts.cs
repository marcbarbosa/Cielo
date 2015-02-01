using Cielo.Helpers;
using Xunit;

namespace Cielo.Facts.Helpers
{
    public class FormatFacts
    {
        public class ToFormatoCielo
        {
            [Fact]
            public void Returns123Given1Point23()
            { 
                // arrange
                var input = 1.23m;
                var expected = 123;

                //act
                var actual = input.ToFormatoCielo();

                // assert
                Assert.Equal(expected, actual);
            }
        }

        public class FromFormatoCielo
        {
            [Fact]
            public void Returns1Point23GivenString123()
            {
                // arrange
                var input = "1234";
                var expected = 12.34m;

                //act
                var actual = input.FromFormatoCielo();

                // assert
                Assert.Equal(expected, actual);
            }
        }
    }
}
