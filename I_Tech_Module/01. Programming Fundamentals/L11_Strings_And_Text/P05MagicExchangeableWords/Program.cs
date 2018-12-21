using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            var firstString = input[0].ToCharArray();
            var secondString = input[1].ToCharArray();

            bool areExchangeable = firstString.Distinct().ToArray().Length == secondString.Distinct().ToArray().Length;

            Console.WriteLine(areExchangeable ? "true" : "false");
        }
    }
}
