using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P08LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex divide = new Regex(@"([A-Z])([\d]+)");
            Regex multiply = new Regex(@"([a-z])([\d]+)");
            Regex substract = new Regex(@"([\d]+)([A-Z])");
            Regex add = new Regex(@"([\d]+)([a-z])");
            Match m = divide.Match(input);

            double sum = 0.0;

            sum = int.Parse(m.Groups[3].ToString());
            Console.WriteLine(sum);
        }
    }
}
