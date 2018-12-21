using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01AssociativeArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] input = Console.ReadLine().Split(' ');
            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (var num in input)
            {
                double parsedNum = double.Parse(num);
                if (counts.ContainsKey(parsedNum))
                {
                    counts[parsedNum]++;
                }
                else
                {
                    counts[parsedNum] = 1;
                }              
            }
            foreach (var num in counts.Keys)
            {
                Console.WriteLine("{0} -> {1}", num, counts[num]);
            }
        }
    }
}
