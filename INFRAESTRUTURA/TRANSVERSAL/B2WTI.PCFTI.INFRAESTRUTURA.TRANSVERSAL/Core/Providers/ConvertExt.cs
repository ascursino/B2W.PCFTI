
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Core.Providers
{
    using System;

    public static class ConvertExt
    {
        const int ZERO = 0;

        public static decimal PercentValue(this decimal? value)
        {
            return (value == null) ? decimal.Parse(ZERO.ToString()) : (decimal)value;
        }

        public static int PercentValue(this short? value)
        {
            return (value == null) ? int.Parse(ZERO.ToString()) : (int)value;
        }

        public static DateTime RequiredDate(this DateTime? value)
        {
            return (value == null) ? DateTime.MinValue : (DateTime)value;
        }

        public static int RequiredInt(this int? value)
        {
            return (value == null) ? int.MinValue : (int)value;
        }
        public static int RequiredInt(this decimal? value)
        {
            return (value == null) ? int.MinValue : (int)value;
        }

        public static bool RequiredBool(this bool? value)
        {
            return (value == null) ? false : (bool)value;
        }

        public static string RequiredString(this string value)
        {
            return (string.IsNullOrEmpty(value)) ? "" : value.ToString();
        }

    }

}
