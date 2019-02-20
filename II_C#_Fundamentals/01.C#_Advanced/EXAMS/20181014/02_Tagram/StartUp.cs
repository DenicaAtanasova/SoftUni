using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Tagram
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, Dictionary<string, int>>();
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "end")
            {
                var input = line.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                if(input[0] == "ban")
                {
                    users.Remove(input[1]);
                }
                else
                {
                    var username = input[0];
                    var tag = input[1];
                    var likes = int.Parse(input[2]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(input[0], new Dictionary<string, int>());
                    }
                    else
                    {
                        if (users[username].ContainsKey(tag))
                        {
                            users[username][tag] += likes;
                        }
                    }

                    if (!users[username].ContainsKey(tag))
                    {
                        users[username].Add(tag, likes);
                    }
                }
            }

            foreach (var user in users.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Keys.Count))
            {
                Console.WriteLine(user.Key);
                foreach (var item in user.Value)
                {
                    Console.WriteLine($"- {item.Key}: {item.Value}");
                }
            }
            
        }
    }
}
