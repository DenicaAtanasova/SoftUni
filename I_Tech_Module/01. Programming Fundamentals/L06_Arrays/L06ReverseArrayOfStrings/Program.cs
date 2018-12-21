using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] items = input.Split(' ');

            string[] reversed = items.Reverse().ToArray();
            Console.WriteLine(String.Join(" ", reversed));
        }
    }
}
