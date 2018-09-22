namespace Task02ChooseADrink2
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            int drinkQty = int.Parse(Console.ReadLine());

            double price;

            switch (profession)
            {
                case "Athlete":
                    price = drinkQty * 0.7;
                    break;
                case "Businessman":
                case "Businesswoman":
                    price = drinkQty * 1.0;
                    break;
                case "SoftUni Student":
                    price = drinkQty * 1.7;
                    break;
                default:
                    price = drinkQty * 1.2;
                    break;
            }
            Console.WriteLine($"The {profession} has to pay {price:0.00}.");
        }
    }
}
