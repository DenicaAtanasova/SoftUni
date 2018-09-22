namespace Task03RestaurantDiscount
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            string hall = "";
            double price = 0.0;
            double pricePerPerson = 0.0;

            if (people <= 50)
            {
                hall = "Small Hall";
                price = 2500;
            }
            else if (people <= 100)
            {
                hall = "Terrace";
                price = 5000;
            }
            else if (people <= 120)
            {
                hall = "Great Hall";
                price = 7500;
            }
            
            switch (package)
            {
                case "Normal":
                    price = 0.95 * (500 + price);
                    break;
                case "Gold":
                    price = 0.9 * (750 + price);
                    break;
                case "Platinum":
                    price = 0.85 * (1000 + price);
                    break;
            }
            if (people > 120)
            {
                    Console.WriteLine("We do not have an appropriate hall.");
            }
            else
            {
                pricePerPerson = price / people;
                Console.WriteLine($"We can offer you the {hall}");
                Console.WriteLine($"The price per person is {pricePerPerson:0.00}$");
            }
        }
    }
}
