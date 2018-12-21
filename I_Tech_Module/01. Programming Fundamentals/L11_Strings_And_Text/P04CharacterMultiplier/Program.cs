using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            var firstString = input[0].Select(x => (int)x).ToList();
            var secondString = input[1].Select(x => (int)x).ToList();

            int length = Math.Max(firstString.Count, secondString.Count);

            if (firstString.Count != secondString.Count)
            {
                for (int i = 0; i <= length; i++)
                {
                    if (i > firstString.Count)
                    {
                        firstString.Add(1);
                    }
                    if (i > secondString.Count)
                    {
                        secondString.Add(1);
                    }
                }
            }
            

            var result = firstString.Zip(secondString, (a, b) => (a * b));

            Console.WriteLine(result.Sum());           
        }
    }
}
