using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03doubleersectionOfCircles
{
    class Program
    {
        static void Main(string[] args)
        {
            double [] circle1Text = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double [] circle2Text = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Circle circle1 = new Circle { Center = new Point { X = circle1Text[0], Y = circle1Text[1] }, Radius = circle1Text[2] };
            Circle circle2 = new Circle { Center = new Point { X = circle2Text[0], Y = circle2Text[1] }, Radius = circle2Text[2] };

            Console.WriteLine(Intersect(circle1, circle2) ? "Yes" : "No");

        }
        static bool Intersect(Circle c1, Circle c2)
        {
            double deltaX = Math.Abs(c1.Center.X - c2.Center.X);
            double deltaY = Math.Abs(c1.Center.Y - c2.Center.Y);

            double centersDistance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            double radiusSum = c1.Radius + c2.Radius;


            return (radiusSum >= centersDistance);
        }

        class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
        class Circle
        {
            public Point Center { get; set; }
            public double Radius { get; set; }
        }
    }
}
