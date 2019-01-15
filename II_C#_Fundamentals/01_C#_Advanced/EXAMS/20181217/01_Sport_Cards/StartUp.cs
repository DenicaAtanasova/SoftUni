using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Sport_Cards
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sportCardsList = new Dictionary<String, Dictionary<string, decimal>>();

            var line = string.Empty;

            while ((line = Console.ReadLine()) != "end")
            {
                var inputArgs = line.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length < 3)
                {
                    var searchedCard = inputArgs[1];

                    var card = sportCardsList.FirstOrDefault(x => x.Key == searchedCard);

                    Console.WriteLine(card.Key == null ? $"{searchedCard} is not available!" : $"{searchedCard} is available!");
                }
                else
                {
                    UpdateSportCardsList(sportCardsList, inputArgs);
                }
            }

            Print(sportCardsList);
        }

        private static void Print(Dictionary<string, Dictionary<string, decimal>> sportCardsList)
        {
            foreach (var sportCard in sportCardsList.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{sportCard.Key}:");

                foreach (var sport in sportCard.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"  -{sport.Key} - {sport.Value:F2}");
                }
            }
        }

        private static void UpdateSportCardsList(Dictionary<String, Dictionary<string, decimal>> sportCardsList, string[] inputArgs)
        {
            var card = inputArgs[0];
            var sport = inputArgs[1];
            var price = decimal.Parse(inputArgs[2]);

            if (!sportCardsList.ContainsKey(card))
            {
                sportCardsList.Add(card, new Dictionary<string, decimal>());
            }

            if (!sportCardsList[card].ContainsKey(sport))
            {
                sportCardsList[card].Add(sport, price);
            }
            else
            {
                sportCardsList[card][sport] = price;
            }
        }
    }
}
