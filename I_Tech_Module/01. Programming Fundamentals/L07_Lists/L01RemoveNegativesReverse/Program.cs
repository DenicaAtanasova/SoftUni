using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01RemoveNegativesReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List <int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
           
            for (int i = numbers.Count -1; i >= 0; i--)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                }
            }
            numbers.Reverse();
            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                foreach (var item in numbers)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
