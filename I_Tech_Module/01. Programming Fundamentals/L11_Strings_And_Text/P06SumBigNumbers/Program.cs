using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().TrimStart('0');           
            var secondInput = Console.ReadLine().TrimStart('0');

            if (firstInput.Length < secondInput.Length)
            {
                firstInput = firstInput.PadLeft(secondInput.Length, '0');
            }
            else
            {
                secondInput = secondInput.PadLeft(firstInput.Length, '0');
            }

            int number = 0;
            int reminder = 0;

            StringBuilder result = new StringBuilder();

            for (int i = firstInput.Length - 1; i >= 0; i--)
            {
                var sum = firstInput[i] - 48 + secondInput[i] - 48 + reminder;
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
