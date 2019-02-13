using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_Predicate_Party_
{
    public static class StartUp
    {
        private static List<string> people;

        static void Main(string[] args)
        {
            Action<List<string>> print = x => Console.WriteLine(x.Count > 0 ?
                string.Join(", ", x) + " are going to the party!" :
                "Nobody is going to the party!");

            people = Console.ReadLine() 
                .Split()
                .ToList();

            var commandLine = string.Empty;

            while ((commandLine = Console.ReadLine()) != "Party!")
            {
                people.UpdatePeoplesList(commandLine);
            }

            print(people);
        }
        
        public static Predicate<string> CreateNameFilter(string[] commandArgs)
        {
            var condition = commandArgs[0];
            var criteria = commandArgs[1];

            switch (condition)
            {
                case "StartsWith":
                    return x => x.StartsWith(criteria);

                case "EndsWith":
                    return x => x.EndsWith(criteria);

                default:
                    return x => x.Length == int.Parse(criteria);
            }
        }

        public static Func<IEnumerable<string>, Predicate<string>, int[]> FindAllIndexes =
                (array, filter) => array
                                    .Select((value, index) => filter(value) ? index : -1)
                                    .Where(index => index != -1)
                                    .ToArray();

        public static Func<List<string>, List<string>> UpdatePeoplesList(this List<string> people, string commandLine)
        {
            var commandArgs = commandLine.Split();

            var nameFilter = CreateNameFilter(commandArgs.Skip(1).ToArray());

            var indexes = FindAllIndexes(people, nameFilter);

            switch (commandArgs[0])
            {
                case "Double":
                    for (int i = indexes.Length - 1; i >= 0; i--)
                    {
                        people.Insert(indexes[i], people[indexes[i]]);
                    }

                    return peopleList => people;

                case "Remove":
                    for (int i = indexes.Length - 1; i >= 0; i--)
                    {
                        people.RemoveAt(indexes[i]);
                    }
                    return peopleList => people;

                default:
                    return peopleList => people;
            }
        }
    }
}
