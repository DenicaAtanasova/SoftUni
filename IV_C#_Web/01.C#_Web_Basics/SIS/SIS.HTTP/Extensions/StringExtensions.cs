namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string text) => text.Substring(0, 1).ToUpper() + text.Substring(1).ToLower();
    }
}
