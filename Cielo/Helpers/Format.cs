
using System.Globalization;

namespace Cielo.Helpers
{
    public static class Format
    {
        public static int ToFormatoCielo(this decimal valor)
        {
            var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            return int.Parse(valor.ToString("N").Replace(decimalSeparator, string.Empty));
        }

        public static decimal FromFormatoCielo(this string valor)
        {
            var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            var s = valor.Insert(valor.Length - 2, decimalSeparator);

            return decimal.Parse(s);
        }
    }
}
