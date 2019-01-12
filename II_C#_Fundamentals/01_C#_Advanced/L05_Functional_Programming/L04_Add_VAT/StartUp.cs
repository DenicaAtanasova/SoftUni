using System;
using System.Linq;

namespace L04_Add_VAT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = x => x * 1.2;

            var prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVAT)
                .Select(y => string.Format($"{0:F2}"));

            Console.WriteLine(string.Join(Environment.NewLine, prices));
        }
    }
}
