using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P01ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([\w.-]+\@[a-zA-Z-]+)(\.[a-zA-Z-]+)+";

            Regex regex = new Regex(pattern);
            MatchCollection emails = regex.Matches(text);

            foreach (Match emailMatches in emails)
            {
                string email = emailMatches.ToString();
                if (!(email.StartsWith(".") || email.StartsWith("-") || email.StartsWith("_") ||
                      email.EndsWith(".") || email.EndsWith("-") || email.EndsWith("_")))
                {
                    Console.WriteLine(email);
                }                
            }
        }
    }
}
