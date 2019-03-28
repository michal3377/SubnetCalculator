using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnetCalculator.Data
{
    public static class Extensions
    {
        public static string ToBinaryString(this UInt32 val) {
            return Convert.ToString(val, 2).PadLeft(32, '0').Insert(24, " ").Insert(16, " ").Insert(8, " ");
        }

        public static string ToBinaryString(this byte val) {
            return Convert.ToString(val, 2).PadLeft(8, '0');
        }
    }
}
