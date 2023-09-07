using System;
using System.Text;

namespace BikeShop.Domain
{
    static class EntityExtensions
    {
        public static string TrimEnd(this StringBuilder sb)
        {
            return sb.ToString().TrimEnd(new char[] { ',', ' ', '|' });
        }
        public static string Bracket(this string item)
        {
            return "[" + item + "]";
        }
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
        public static object OrNow(this object value)
        {
            if (value != null && value.ToString() == "getdate()")
                return DateTime.Now;
            return value;
        }
    }
}