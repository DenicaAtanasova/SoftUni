
namespace SIS.HTTP.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string Capitalize(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException($"{nameof(input)} cannot be null or empty", nameof(input));

            return Char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
