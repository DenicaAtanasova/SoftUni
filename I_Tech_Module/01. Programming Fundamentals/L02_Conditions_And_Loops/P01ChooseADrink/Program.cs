namespace Task01ChooseADrink
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            string drink;

            switch (profession)
            {
                case "Athlete":
                    drink = "Water";
                    break;
                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee";
                    break;
                case "SoftUni Student":
                    drink = "Beer";
                    break;
                default:
                    drink = "Tea";
                    break;
            }
            Console.WriteLine(drink);
        }
    }
}
