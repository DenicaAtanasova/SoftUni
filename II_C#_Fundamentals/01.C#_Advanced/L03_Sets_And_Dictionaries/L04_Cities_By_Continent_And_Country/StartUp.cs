using System;
using System.Collections.Generic;

namespace L04_Cities_By_Continent_And_Country
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var atlas = new Dictionary<string, Dictionary<string, List<string>>>();

            while (n-- > 0)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var continet = input[0];
                var country = input[1];
                var city = input[2];

                if (!atlas.ContainsKey(continet))
                {
                    atlas.Add(continet, new Dictionary<string, List<string>>());
                    atlas[continet].Add(country, new List<string>());
                }
                else
                {
                    if (!atlas[continet].ContainsKey(country))
                    {
                        atlas[continet].Add(country, new List<string>());
                    }
                }

                atlas[continet][country].Add(city);
            }

            foreach (var continet in atlas)
            {
                Console.WriteLine($"{continet.Key}:");

                foreach (var country in continet.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
