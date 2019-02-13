using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Ranking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var candidates = new Dictionary<string, Dictionary<string, int>>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var contestArgs = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                var contest = contestArgs[0];
                var password = contestArgs[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var candidatesArgs = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                var contest = candidatesArgs[0];
                var password = candidatesArgs[1];
                var username = candidatesArgs[2];
                var points = int.Parse(candidatesArgs[3]);

                var isValidContest = contests.ContainsKey(contest) && contests[contest] == password;
                if (isValidContest)
                {
                    if (candidates.ContainsKey(username))
                    {
                        if (!candidates[username].ContainsKey(contest))
                        {
                            candidates[username].Add(contest, points);
                        }
                        else if (points > candidates[username][contest])
                        {
                            candidates[username][contest] = points;
                        }
                    }
                    else
                    {
                        candidates.Add(username, new Dictionary<string, int>());
                        candidates[username].Add(contest, points);
                    }
                }
            }

            var bestCandidate = candidates.OrderByDescending(x => x.Value.Values.Sum()).First();
            var candidateName = bestCandidate.Key;
            var candidatePoints = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {candidateName} with total {candidatePoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
