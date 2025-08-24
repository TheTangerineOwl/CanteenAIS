using System;

namespace CanteenAIS_ViewModel
{
    public static class ValueChecker
    {
        public static string CheckValueString(string line)
        {
            return !string.IsNullOrWhiteSpace(line) ? line : null;
        }

        public static uint CheckValueUint(string line)
        {
            return uint.TryParse(line, out uint value) ? value : 0;
        }

        public static decimal CheckValueDecimal(string line)
        {
            return decimal.TryParse(line, out decimal value) ? value : -1;
        }

        public static double CheckValueDouble(string line)
        {
            return double.TryParse(line, out double value) ? value : -1;
        }

        public static DateTime CheckValueDateTime(string line)
        {
            return DateTime.TryParse(line, out DateTime value) ? value : DateTime.MinValue;
        }
    }
}
