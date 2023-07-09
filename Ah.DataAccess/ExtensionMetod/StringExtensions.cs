using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.DataAccess.ExtensionMetod
{
    public static class StringExtensions
    {
        public static decimal ToDollar(this string str, decimal kur)
        {
            return Convert.ToDecimal(str) / kur;
        }
    }
}
