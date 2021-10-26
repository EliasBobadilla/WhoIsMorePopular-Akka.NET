using System.Collections.Generic;
using System.Linq;

namespace WhoIsMorePopular.Common
{
    public static class Helpers
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }
        
        public static string GetTextBetween(this string str, string left, string right)
        {
            var list = str.Split(left);
            if (!list.Any()) return "";
            var values = list.Last().Split(right);
            return values.First();
        }
        
        public static string OnlyNumbers(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "0" : new string(value.Where(char.IsDigit).ToArray());
        }
        
        public static int GetMaxLength(this IEnumerable<string> values)
        {
            return values.Select(value => value.Length).Prepend(0).Max() + 1;
        }
        
        public static string FixLength(this string value, int len)
        {
            return value.PadRight(len);
        }
        
        public static string TextToQuery(this string text)
        {
            var value = text.Replace(" ", "+");
            return value.ToLower();
        }
    }
}