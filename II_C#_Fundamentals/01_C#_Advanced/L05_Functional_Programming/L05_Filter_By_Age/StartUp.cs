using System;
using System.Collections.Generic;
using System.Linq;

namespace L05_Filter_By_Age
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>(n);

            while (n-- > 0)
            {
                var peopleInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(peopleInfo[0], int.Parse(peopleInfo[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            var format = Console.ReadLine();

            var filter = CreateFilter(condition, age);

            var printer = CreatePrinter(format);

            people.Where(x => filter(x.Value))
                .ToList()
                .ForEach(printer);           
        }

        public static Func<int, bool> CreateFilter(string condition, int age)
        {
            if (condition == "older")
            {
                return x => x >= age;
            }

            return x => x < age;
        }

        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");                   
                default:
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
            }
        }
    }
}
