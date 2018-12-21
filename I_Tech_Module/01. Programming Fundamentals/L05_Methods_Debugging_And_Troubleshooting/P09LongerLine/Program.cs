using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstLineX1 = double.Parse(Console.ReadLine());
            double firstLineY1 = double.Parse(Console.ReadLine());
            double firstLineX2 = double.Parse(Console.ReadLine());
            double firstLineY2 = double.Parse(Console.ReadLine());

            double secondLineX1 = double.Parse(Console.ReadLine());
            double secondLineY1 = double.Parse(Console.ReadLine());
            double secondLineX2 = double.Parse(Console.ReadLine());
            double secondLineY2 = double.Parse(Console.ReadLine());

            GetLongerLine(firstLineX1, firstLineY1, firstLineX2, firstLineY2,
                          secondLineX1, secondLineY1, secondLineX2, secondLineY2);
        }

        private static void GetLongerLine(double firstLineX1, double firstLineY1, double firstLineX2, double firstLineY2,
                                          double secondLineX1, double secondLineY1, double secondLineX2, double secondLineY2)
        {
            double firstLineLength = Math.Sqrt((Math.Pow((firstLineX2 - firstLineX1), 2) - Math.Pow((firstLineY2 - firstLineY1), 2)));
            double secondLineLength = Math.Sqrt((Math.Pow((secondLineX2 - secondLineX1), 2) - Math.Pow((secondLineY2 - secondLineY1), 2)));

            if (firstLineLength >= secondLineLength)
            {
                GetCenterPoint(firstLineX1, firstLineY1, firstLineX2, firstLineY2);
            }
            else
            {
                GetCenterPoint(secondLineX1, secondLineY1, secondLineX2, secondLineY2);
            }
        }

        static void GetCenterPoint(double x1, double y1, double x2, double y2)
        {
            double firstPoin = Math.Abs(x1 - 0) + Math.Abs(y1 - 0);
            double secondPoin = Math.Abs(x2 - 0) + Math.Abs(y2 - 0);
            if (firstPoin <= secondPoin)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}
