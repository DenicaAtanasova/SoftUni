using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L04DistanceBetweenPoints
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Point p1 = ReadPoint();
            Point p2 = ReadPoint();
            Console.WriteLine("{0:F3}", CalcDistance(p1, p2));
        }  
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        static Point ReadPoint()
        {
            int[] coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            return new Point() {X = coordinates[0], Y = coordinates[1]};
        }
        static double CalcDistance(Point p1, Point p2)
        {
            int deltaX = p1.X - p2.X;
            int deltaY = p1.Y - p2.Y;

            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }
    }
}
