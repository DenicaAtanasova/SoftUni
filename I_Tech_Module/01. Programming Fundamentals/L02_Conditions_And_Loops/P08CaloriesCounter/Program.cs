namespace Task07CaloriesCounter
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int caloriesCounter = 0;

            for (int i = 0; i < n; i++)
            {
                string ingridient = Console.ReadLine().ToLower();
                switch (ingridient)
                {
                    case "cheese":
                        caloriesCounter += 500;
                        break;
                    case "tomato sauce":
                        caloriesCounter += 150;
                        break;
                    case "salami":
                        caloriesCounter += 600;
                        break;
                    case "pepper":
                        caloriesCounter += 50;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Total calories: {caloriesCounter}");
        }
    }
}
