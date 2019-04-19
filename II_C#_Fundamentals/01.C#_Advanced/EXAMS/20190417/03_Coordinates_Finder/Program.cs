using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03_Coordinates_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^([A-Za-z\d!@#$?]+)=(\d+)<<(.+)$";

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Last note")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(input);

                    var name = match.Groups[1].Value;
                    var length = int.Parse(match.Groups[2].Value);
                    var code = match.Groups[3].Value;

                    if (code.Length != length)
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }

                    var decryptedName = DecryptName(name);
                    Console.WriteLine($"Coordinates found! {decryptedName} -> {code}");
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }

        private static string DecryptName(string name)
        {
            var decryptedName = new String(name.Where(x => Char.IsLetter(x) || Char.IsDigit(x)).ToArray());

            return decryptedName;
        }
    }
}
