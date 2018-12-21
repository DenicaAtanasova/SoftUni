using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08CenterPoint
{
    class Program
    {
       
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            GetCenterPoint(x1, y1, x2, y2);
        }

        static void GetCenterPoint(double x1, double y1, double x2, double y2)
        {
            double firstPoin = Math.Abs(x1 - 0) + Math.Abs(y1 - 0); 
            double secondPoin = Math.Abs(x2 - 0) + Math.Abs(y2 - 0);
            if (firstPoin <= secondPoin)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}
