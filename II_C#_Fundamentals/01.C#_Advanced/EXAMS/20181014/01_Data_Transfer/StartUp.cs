using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01_Data_Transfer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dataTransferSize = 0;

            while (n-- >0)
            {
                var input = Console.ReadLine().Split(';',  StringSplitOptions.RemoveEmptyEntries);

                if(input.Length < 3)
                {
                    continue;
                }

                var message = string.Empty;
                var messsagePattern = "^m--(\"[A-Za-z\\s]+\")$";
                if (Regex.IsMatch(input[2], messsagePattern))
                {
                    message = input[2].TrimStart('m', '-');

                    var namePattern = @"[A-Za-z\s]+";
                    if(input[0].Substring(0,2) != "s:" || input[1].Substring(0, 2) != "r:")
                    {
                        continue;
                    }

                    var sender = string.Join("", Regex.Matches(input[0].TrimStart('s', ':'), namePattern));
                    var receiver = string.Join("", Regex.Matches(input[1].TrimStart('r', ':'), namePattern));

                    Console.WriteLine($"{sender} says {message} to {receiver}");
                    dataTransferSize += Regex.Matches(input[0], "\\d")
                            .Cast<Match>()
                            .Select(m => int.Parse(m.Value)).Sum();

                    dataTransferSize += Regex.Matches(input[1], "\\d")
                            .Cast<Match>()
                            .Select(m => int.Parse(m.Value)).Sum();
                }
            }

            Console.WriteLine($"Total data transferred: {dataTransferSize}MB");
        }
    }
}
