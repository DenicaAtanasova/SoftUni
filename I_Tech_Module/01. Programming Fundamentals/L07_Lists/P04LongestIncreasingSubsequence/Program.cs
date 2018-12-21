using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var commands = Console.ReadLine().Split(' ').ToArray();
            int index = int.Parse(commands[1]);

            while (commands[0] != ("print"))
            {

                switch (commands[0])
                {                    
                    case "add":
                        numbers.Insert(index, int.Parse(commands[2]));
                        break;
                    case "addMany":
                        int elemetsCount = 2;
                        for (int i = index; i < commands.Length; i++)
                        {
                            numbers.Insert(index, int.Parse(commands[elemetsCount]));
                            elemetsCount++;
                        }
                        break;
                    case "contains":
                        Console.WriteLine(numbers.IndexOf(index));
                        break;
                    case "remove":
                        numbers.RemoveAt(index);
                        break;
                    case "shift":
                        List<int> lastNUms = numbers.Take(index).ToList();
                        numbers = numbers.Skip(index).Take(numbers.Count - index).ToList();
                        foreach (var num in lastNUms)
                        {
                            numbers.Add(num);
                        }
                        break;
                    case "sumPairs":
                        int sum = 0;
                        int sumIndex = 0;
                        for (int i = 1; i < numbers.Count; i += 2)
                        {
                            sum += numbers[i] + numbers[i - 1];
                            numbers[0] = sum;
                            sumIndex++;
                        }
                        break;
                }
                commands = Console.ReadLine().Split(' ').ToArray();
            }
            if (commands[0] == "print")
            {
                Console.WriteLine("[" + string.Join(" ", numbers) + "]");
            }
        }
    }
}
