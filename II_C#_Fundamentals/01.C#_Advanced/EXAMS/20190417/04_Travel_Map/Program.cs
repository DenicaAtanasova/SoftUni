using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Travel_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Dictionary<string, Dictionary<string, int>>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split(" > ", StringSplitOptions.RemoveEmptyEntries);
                var country = inputArgs[0];
                var town = inputArgs[1];
                var travelCost = int.Parse(inputArgs[2]);

                if (!map.ContainsKey(country))
                {
                    map.Add(country, new Dictionary<string, int>());
                }

                if (!map[country].ContainsKey(town))
                {
                    map[country].Add(town, travelCost);
                }

                if (map[country][town] > travelCost)
                {
                    map[country][town] = travelCost;
                }
            }

            var sb = new StringBuilder();
            foreach (var country in map.OrderBy(c => c.Key))
            {
                sb.Append($"{country.Key} ->");

                foreach(var town in country.Value.OrderBy(t => t.Value))
                {
                    sb.Append($" {town.Key} -> {town.Value}");
                }
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
