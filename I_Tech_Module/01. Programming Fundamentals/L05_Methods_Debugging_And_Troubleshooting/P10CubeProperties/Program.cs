using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            GetCubParameter(side, parameter);
        }

        private static void GetCubParameter(double side, string parameter)
        {
            double result = 0;
            switch (parameter)
            {
                case "face":
                    result = Math.Sqrt(2 * Math.Pow(side, 2));
                    break;
                case "space":
                   result = Math.Sqrt(3 * Math.Pow(side, 2));
                    break;
                case "volume":
                    result = Math.Pow(side, 3);
                    break;
                case "area":
                    result = 6 * Math.Pow(side, 2);
                    break;
            }
            Console.WriteLine("{0:F2}", result);
        }
    }
}
