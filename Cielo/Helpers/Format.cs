using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cielo.Helpers
{
    public static class Format
    {
        public static int CieloFormat(this decimal valor)
        {
            return int.Parse(valor.ToString().Replace(",", string.Empty).Replace(".", string.Empty));
        }
    }
}
