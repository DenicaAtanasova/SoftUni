using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').ToList();
            string command = Console.ReadLine();
            var operation = command.Split(' ').ToList();

            while (command != "Odd" && command != "Even")
            {
                switch (operation[0])
                {
                    case "Delete":
                        while (numbers.Contains(operation[1]))
                        {
                            numbers.Remove(operation[1]);
                        }
                        break;
                    case "Insert":
                        var index = int.Parse(operation[2]);
                        numbers.Insert(index, operation[1]);
                        break;
                }
                command = Console.ReadLine();
                operation = command.Split(' ').ToList();
            }
            numbers.Select(int.Parse);
            if (operation[0] == "Even")
            {
                foreach (var item in numbers)
                {
                    int n = int.Parse(item);
                    if (n % 2 == 0)
                    {
                        Console.Write(n + " ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                foreach (var item in numbers)
                {
                    int n = int.Parse(item);
                    if (n % 2 != 0)
                    {
                        Console.Write(n + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
