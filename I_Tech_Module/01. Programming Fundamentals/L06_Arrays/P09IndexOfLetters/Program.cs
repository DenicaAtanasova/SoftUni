using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {

            var letters = Console.ReadLine().ToCharArray();
            char[] alphabetLetters = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                                    'n','o','p','q','r','s','t','u','v','w','x','y','z'};

            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = 0; j < alphabetLetters.Length; j++)
                {
                    if (letters[i].Equals(alphabetLetters[j]))
                    {
                        Console.WriteLine("{0} -> {1}", letters[i], j);
                        break;
                    }
                }
            }
        }
    }
}
