using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Count_Symbols
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var symbols = Console.ReadLine().ToCharArray();

            var symbolsCounter = new Dictionary<char, int>();

            foreach (var symbol in symbols)
            {
                if (symbolsCounter.ContainsKey(symbol))
                {
                    symbolsCounter[symbol]++;
                }
                else
                {
                    symbolsCounter.Add(symbol, 1);
                }
            }

            foreach (var symbol in symbolsCounter.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
