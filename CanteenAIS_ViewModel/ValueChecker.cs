using System;

namespace CanteenAIS_ViewModel
{
    public static class ValueChecker
    {
        public static bool CheckValueString(string line, out string result, uint maxLength, bool nullable = true)
        {
            //return !string.IsNullOrWhiteSpace(line) ? line : null;
            result = null;
            if ((string.IsNullOrEmpty(line) && !nullable) || line.Length > maxLength)
                return false;
            result = line;
            return true;
        }

        public static bool CheckValueUint(string line, out uint result, bool nullable = false)
        {
            //return uint.TryParse(line, out uint value) ? value : 0;
            if (!uint.TryParse(line, out result))
            {
                result = 0;
                return false;
            }
            else if (!nullable && result == 0)
                return false;
            return true;
        }

        public static bool CheckValueDecimal(string line, out decimal result, bool nullable = false, bool signed = false)
        {
            //return decimal.TryParse(line, out decimal value) ? value : -1;
            if (!decimal.TryParse(line, out result))
            {
                result = 0;
                return false;
            }
            else if ((!nullable) && (result == 0 || (signed && result < 0)))
                return false;
            return true;
        }

        public static bool CheckValueDouble(string line, out double result, bool nullable = false, bool signed = false)
        {
            //return double.TryParse(line, out double value) ? value : -1;
            if (!double.TryParse(line, out result))
            {
                result = 0;
                return false;
            }
            else if ((!nullable) && (result == 0 || (signed && result < 0)))
                return false;
            return true;
        }

        public static bool CheckValueDateTime(string line, out DateTime result, bool nullable = false)
        {
            //return DateTime.TryParse(line, out DateTime value) ? value : DateTime.MinValue;
            if (!DateTime.TryParse(line, out result))
            {
                result = DateTime.MinValue;
                return false;
            }
            else if (!nullable && result == DateTime.MinValue)
                return false;
            return true;
        }
    }
}
