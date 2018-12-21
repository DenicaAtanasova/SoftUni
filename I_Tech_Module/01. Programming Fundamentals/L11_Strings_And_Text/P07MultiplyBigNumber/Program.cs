using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = Console.ReadLine().TrimStart('0');
            var seconNumber = Console.ReadLine().TrimStart('0');

            int number = 0;
            int reminder = 0;

            StringBuilder result = new StringBuilder();
            if (firstNumber.Equals("") || seconNumber.Equals(""))
            {
                Console.WriteLine("0");
            }
            else
            {
                for (int i = firstNumber.Length - 1; i >= 0; i--)
                {
                    var sum = int.Parse(firstNumber[i].ToString()) * int.Parse(seconNumber) + reminder;
                    number = sum % 10;
                    result.Append(number);
                    reminder = sum / 10;

                    if (i == 0 && reminder != 0)
                    {
                        result.Append(reminder);
                    }
                }
                Console.WriteLine(new string(result.ToString().ToCharArray().Reverse().ToArray()));
            }            
        }
    }
}
