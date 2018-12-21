using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02ReverseArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                numbers[i] = int.Parse(Console.ReadLine());
               
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
