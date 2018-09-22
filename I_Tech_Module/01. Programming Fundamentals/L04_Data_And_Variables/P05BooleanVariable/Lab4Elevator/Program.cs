namespace Lab4Elevator
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int peopleQty = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling(peopleQty / (double)capacity);          
            Console.WriteLine(courses);
        }
    }
}
