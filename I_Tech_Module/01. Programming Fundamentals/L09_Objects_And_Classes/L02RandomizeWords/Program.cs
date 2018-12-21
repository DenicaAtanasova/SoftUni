using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] words = Console.ReadLine().Split(' ');
            Random random = new Random { };
            for (int pos1 = 0; pos1 < words.Length; pos1++)
            {
                int pos2 = random.Next(words.Length);
                string oldPos1 = words[pos1];
                words[pos1] = words[pos2];
                words[pos2] = oldPos1;
            }
            Console.WriteLine(String.Join(Environment.NewLine, words));
        }
    }
}
