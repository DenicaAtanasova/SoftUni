using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03SearchForNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').ToList();
            int [] manipulator = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            numbers = numbers.Take(manipulator[0]).ToList();
            for (int i = 0; i < manipulator[1]; i++)
            {
                numbers.RemoveAt(0);
            }
            string searchedNum = "" + manipulator[2];
            if (numbers.Contains(searchedNum))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
