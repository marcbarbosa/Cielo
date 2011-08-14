using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cielo.Helpers
{
    public static class Format
    {
        public static int ToFormatoCielo(this decimal valor)
        {
            return int.Parse(valor.ToString("N").Replace(",", string.Empty).Replace(".", string.Empty));
        }

        public static decimal FromFormatoCielo(this string valor)
        {
            var s = valor.Insert(valor.Length - 2, ",");

            return decimal.Parse(s);
        }
    }
}
