using System;
using System.Linq;

namespace AgendaMatic.Repository.Extensions
{
    public static class DataTypesExtension
    {
        static Func<char, string> AddUnderscoreBeforeCapitalLetter = x => char.IsUpper(x) ? "_" + x : x.ToString();

        public static string ToDatabaseFormat(this string value)
        {
            return string.Concat(value.Select(AddUnderscoreBeforeCapitalLetter)).Substring(1).ToLower();
        }
    }
}
