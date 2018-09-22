namespace Lab6TheatrePromotions
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string dayType = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());

            if (age > 122 || age < 0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                switch (dayType)
                {
                    case "weekday":
                        if (0 <= age && age <= 18)
                        {
                            Console.WriteLine("12$");
                        }
                        else if (18 < age && age <= 64)
                        {
                            Console.WriteLine("18$");
                        }
                        else if (64 < age && age <= 122)
                        {
                            Console.WriteLine("12$");
                        }
                        break;
                    case "weekend":
                        if (0 <= age && age <= 18)
                        {
                            Console.WriteLine("15$");
                        }
                        else if (18 < age && age <= 64)
                        {
                            Console.WriteLine("20$");
                        }
                        else if (64 < age && age <= 122)
                        {
                            Console.WriteLine("15$");
                        }
                        break;
                    case "holiday":
                        if (0 <= age && age <= 18)
                        {
                            Console.WriteLine("5$");
                        }
                        else if (18 < age && age <= 64)
                        {
                            Console.WriteLine("12$");
                        }
                        else if (64 < age && age <= 122)
                        {
                            Console.WriteLine("10$");
                        }
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
        }
    }
}
