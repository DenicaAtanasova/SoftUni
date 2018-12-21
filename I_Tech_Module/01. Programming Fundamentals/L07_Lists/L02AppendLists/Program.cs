using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split('|').ToArray();
            List<string> appendList = new List<string>();

            for (int i = tokens.Length - 1; i >= 0; i--)
            {
                string[] result = tokens[i].Split(' ').ToArray();
                for (int j = 0; j < result.Length; j++)
                {
                    if (result[j] != "")
                    {
                        appendList.Add(result[j]);
                    }
                }              
            }
            Console.WriteLine(string.Join(" ", appendList));
        }
    }
}
