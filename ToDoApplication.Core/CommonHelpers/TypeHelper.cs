using System;

namespace ToDoApplication.Core.CommonHelpers
{
    public static class TypeHelper
    {
        public static int ToInt(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return (int)decimal.MinusOne;
            }
        }

        public static decimal ToDecimal(this object value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return decimal.MinusOne;
            }
        }

        public static double ToDouble(this object value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0.0;
            }
        }

        public static bool ToBoolean(this object value)
        {
            bool returnValue = false;

            try { returnValue = Convert.ToBoolean(value); }
            catch { }

            return returnValue;
        }

        public static DateTime ToDateTime(this object value)
        {
            DateTime returnValue = default(DateTime);

            try { returnValue = Convert.ToDateTime(value); }
            catch { }

            return returnValue;
        }

        public static Int64 ToLong(this object value)
        {
            var returnValue = (Int64)decimal.MinusOne;
            try
            {
                returnValue = Convert.ToInt64(value);
            }
            catch
            {
            }
            return returnValue;
        }

        public static bool IsNotNull(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNull(this DateTime value)
        {
            return (value != null && value != default(DateTime)) ? true : false;
        }

        public static bool IsNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        public static bool IsNull(this DateTime value)
        {
            return (value == null || value == default(DateTime)) ? true : false;
        }
    }
}
