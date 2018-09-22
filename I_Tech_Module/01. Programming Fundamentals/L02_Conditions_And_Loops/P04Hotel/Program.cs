namespace Task04Hotel
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightCounts = int.Parse(Console.ReadLine());

            double priceStudio = 0.0;
            double priceDouble = 0.0;
            double priceSuite = 0.0;

            switch (month)
            {
                case "May" :
                case "October" :
                    priceStudio = 50.0 * nightCounts;
                    priceDouble = 65.0 * nightCounts;
                    priceSuite = 75.0 * nightCounts;
                    break;

                case "June" :
                case "September" :
                    priceStudio = 60.0 * nightCounts;
                    priceDouble = 72.0 * nightCounts;
                    priceSuite = 82.0 * nightCounts;
                    break;

                case "July":
                case "August":
                case "December":
                    priceStudio = 68.0 * nightCounts;
                    priceDouble = 77.0 * nightCounts;
                    if (nightCounts > 14)
                    {
                        priceSuite = 0.85 * 89.0 * nightCounts;
                    }
                    else
                    {
                        priceSuite = 89.0 * nightCounts;
                    }

                    break;                    
            }
            if (nightCounts > 7)
            {
                switch (month)
                {
                    case "May":
                        priceStudio = 0.95 * 50.0 * nightCounts;
                        break;
                    case "September":
                        priceStudio = 60.0 * (nightCounts - 1);
                        break;
                    case "October":
                        priceStudio = 0.95 * 50.0 * (nightCounts - 1);
                        break;
                }
            }
            Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
            Console.WriteLine("Double: {0:F2} lv.", priceDouble);
            Console.WriteLine("Suite: {0:F2} lv.", priceSuite);
        }
    }
}
