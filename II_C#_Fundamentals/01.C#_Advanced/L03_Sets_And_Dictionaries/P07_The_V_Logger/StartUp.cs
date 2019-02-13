using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_The_V_Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var username = inputArgs[0];
                var action = inputArgs[1];

                switch (action)
                {
                    case "joined":
                        if (!vloggers.ContainsKey(username))
                        {
                            vloggers.Add(username, new Dictionary<string, HashSet<string>>());
                            vloggers[username].Add("followers", new HashSet<string>());
                            vloggers[username].Add("followings", new HashSet<string>());
                        }
                        break;
                    case "followed":
                        var vlogger = inputArgs[2];

                        if (vlogger != username && vloggers.ContainsKey(username) && vloggers.ContainsKey(vlogger))
                        {
                            vloggers[username]["followings"].Add(vlogger);
                            vloggers[vlogger]["followers"].Add(username);
                        }                        
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var vloggersCount = 1;

            foreach (var vlogger in vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x =>x.Value["followings"].Count))
            {
                var followers = vlogger.Value["followers"].Count;
                var followings = vlogger.Value["followings"].Count;

                Console.WriteLine($"{vloggersCount}. {vlogger.Key} : {followers} followers, {followings} following");

                if (vloggersCount == 1)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                vloggersCount++;
            }
        }
    }
}
