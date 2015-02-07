
using System.Globalization;
using System.Text.RegularExpressions;

namespace Cielo.Helpers
{
    public static class Format
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");

        public static int ToFormatoCielo(this decimal valor)
        {
            return int.Parse(digitsOnly.Replace(valor.ToString("N"), string.Empty));
        }

        public static decimal FromFormatoCielo(this string valor)
        {
            valor = digitsOnly.Replace(valor, string.Empty);

            if (!string.IsNullOrWhiteSpace(valor))
            {
                var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                if (valor.Length == 1)
                {
                    valor = string.Concat("0", valor);
                }

                var s = valor.Insert(valor.Length - 2, decimalSeparator);

                return decimal.Parse(s);
            }

            return 0m;
        }
    }
}
