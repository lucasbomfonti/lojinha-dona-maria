using System.Text.RegularExpressions;

namespace Lojinha.DonaMaria.Helper
{
    public class NumberHelper
    {
        public static string OnlyNumbers(string txt)
        {
            if (txt == null)
            {
                return string.Empty;
            }

            var regexObj = new Regex(@"[^\d]");
            return regexObj.Replace(txt.Trim(), string.Empty);
        }
    }
}
