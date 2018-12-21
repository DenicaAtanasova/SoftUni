using System;
using System.Collections.Generic;
using System.Linq;

namespace P07PopulationCounter
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> populationReport = new Dictionary<string, Dictionary<string, long>>();

            string[] input = Console.ReadLine().Split('|').ToArray();
            while (input[0] != "report")
            {
                string city = input[0];
                string country = input[1];
                long population = long.Parse(input[2]);

                if (!populationReport.ContainsKey(country))
                {
                    populationReport.Add(country, new Dictionary<string, long>());
                    populationReport[country].Add(city, population);
                }
                else if (populationReport.ContainsKey(country))
                {
                    populationReport[country].Add(city, population);
                }

                input = Console.ReadLine().Split('|').ToArray();               
            }
            populationReport.OrderByDescending(x => x.Value.Sum(y => y.Value));

            foreach (var state in populationReport.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                List<long> sumOfTowns = state.Value.Select(x => x.Value).ToList();
                Console.WriteLine($"{state.Key} (total population: {sumOfTowns.Sum()})");

                Console.Write($"=>{string.Join("=>", state.Value.OrderByDescending(x => x.Value).Select(x => $"{x.Key}: {x.Value}\r\n"))}");
            }
        }
    }
}
