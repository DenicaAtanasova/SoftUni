using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P11GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine().ToLower();
            GeometryCalculator(figureType);
        }

        private static void GeometryCalculator(string figureType)
        {
            double result = 0;
            switch (figureType)
            {
                case "triangle":
                    double c = double.Parse(Console.ReadLine());
                    double hc = double.Parse(Console.ReadLine());
                    result = c * hc / 2;
                    break;
                case "square":
                    double side = double.Parse(Console.ReadLine());
                    result = side * side;
                    break;
                case "rectangle":
                    double a = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    result = a * b;
                    break;
                case "circle":
                    double r = double.Parse(Console.ReadLine());
                    result = Math.PI * Math.Pow(r, 2);
                    break;
            }
            Console.WriteLine("{0:F2}", result);
        }
    }
}
