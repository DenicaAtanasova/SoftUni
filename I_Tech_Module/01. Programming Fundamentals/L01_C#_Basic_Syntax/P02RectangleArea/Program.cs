namespace Task2RectangleArea
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double rectangleArea = width * height;

            Console.WriteLine($"{rectangleArea:0.00}");
        }
    }
}
