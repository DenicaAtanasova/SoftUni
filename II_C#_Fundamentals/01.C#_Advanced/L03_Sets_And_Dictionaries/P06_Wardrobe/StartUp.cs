using System;
using System.Collections.Generic;

namespace P06_Wardrobe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var wordrobe = new Dictionary<string, Dictionary<string, int>>();

            while (n-- > 0)
            {
                var input = Console.ReadLine().
                    Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var color = input[0];
                var clothes = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in clothes)
                {
                    if (wordrobe.ContainsKey(color))
                    {
                        if (wordrobe[color].ContainsKey(item))
                        {
                            wordrobe[color][item]++;
                        }
                        else
                        {
                            wordrobe[color].Add(item, 1);
                        }
                    }
                    else
                    {
                        wordrobe.Add(color, new Dictionary<string, int>());
                        wordrobe[color].Add(item, 1);
                    }
                }
            }

            var searchedItem = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var itemColor in wordrobe)
            {
                Console.WriteLine($"{itemColor.Key} clothes:");

                foreach (var item in itemColor.Value)
                {
                    if (itemColor.Key == searchedItem[0] && item.Key == searchedItem[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
