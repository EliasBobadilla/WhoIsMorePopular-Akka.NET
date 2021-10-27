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
        
        public static long OnlyNumbers(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            var number = new string(value.Where(char.IsDigit).ToArray());
            return number.Length > 10 ? 0 : long.Parse(number);
        }
        
        public static string TextToQuery(this string text)
        {
            var value = text.Replace(" ", "+");
            return value.ToLower();
        }
    }
}