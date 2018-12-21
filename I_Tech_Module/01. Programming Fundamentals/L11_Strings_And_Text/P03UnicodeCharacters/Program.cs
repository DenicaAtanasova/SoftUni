using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            char [] input = Console.ReadLine().ToCharArray();
            foreach (var symbol in input)
            {
                Console.Write(GetEscapeSequence(symbol));
            }
            Console.WriteLine();

        }
        static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("x4");
        }
    }
}
