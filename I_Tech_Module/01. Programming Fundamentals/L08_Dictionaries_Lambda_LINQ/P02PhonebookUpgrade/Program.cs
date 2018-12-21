using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02PhonebookUpgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();

            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "A":
                        phonebook[input[1]] = input[2];
                        break;
                    case "S":
                        if (phonebook.ContainsKey(input[1]))
                        {
                            Console.WriteLine($"{input[1]} -> {phonebook[input[1]]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {input[1]} does not exist.");
                        }
                        break;
                    case "ListAll":
                        foreach (KeyValuePair<string, string> pair in phonebook)
                        {
                            Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                        }
                        break;
                }
                input = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
