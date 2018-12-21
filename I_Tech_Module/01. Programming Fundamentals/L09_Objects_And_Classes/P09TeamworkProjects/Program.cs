using System;
using System.Collections.Generic;
using System.Linq;

namespace P09TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teamList = new List<Team>();
            string input = "";

            while (n-- > 0)
            {
                input = Console.ReadLine();
                string[] creatorsAndTeams = input.Split('-').ToArray();
                string teamCreator = creatorsAndTeams[0];
                string teamName = creatorsAndTeams[1];

                bool hasCreated = teamList.Any(x => x.Creator == teamCreator);
                bool IsCreated = teamList.Any(x => x.Name == teamName);

                if (IsCreated)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (hasCreated)
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                }
                if (!IsCreated && !hasCreated)
                {
                    Team team = new Team();
                    team.Name = teamName;
                    team.Creator = teamCreator;
                    team.Members = new List<string>();

                    Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
                    teamList.Add(team);
                }
            }

            List<string> members = new List<string>();
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] membersAndTeams = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string member = membersAndTeams[0];
                string teamToJoin = membersAndTeams[1];

                bool isExisting = teamList.Any(x => x.Name == teamToJoin);
                bool isJoined = teamList.Any(x => x.Members.Contains(member));

                bool hasCreated = teamList.Any(x => x.Creator == member);

                if (!isExisting)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (isJoined || hasCreated)
                {
                    Console.WriteLine($"Member {member} cannot join team {teamToJoin}!");
                }
                else
                {
                    teamList.First(x => x.Name == teamToJoin).Members.Add(member);
                }
            }

            foreach (var team in teamList.Where(x => x.Members.Count != 0).OrderByDescending(x => x.Members.Count).ThenBy(y => y.Name))
            {
                Console.WriteLine(team.Name + Environment.NewLine + "- " + team.Creator);
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");

            foreach (var team in teamList.Where(x => x.Members.Count == 0).OrderBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
            }

        }
    }
    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
