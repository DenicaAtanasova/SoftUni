using System;
using System.Collections.Generic;
using System.Linq;

namespace L03_Product_Shop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;

            var shop = new Dictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                var shopAndroduct = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var shopName = shopAndroduct[0];
                var product = shopAndroduct[1];
                var price = double.Parse(shopAndroduct[2]);

                if (!shop.ContainsKey(shopName))
                {
                    shop.Add(shopName, new Dictionary<string, double>());
                }

                shop[shopName].Add(product, price);
            }

            foreach (var sh in shop.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sh.Key}->");

                foreach (var prod in sh.Value)
                {
                    Console.WriteLine($"Product: {prod.Key}, Price: {prod.Value}");
                }
            }
        }
    }
}
