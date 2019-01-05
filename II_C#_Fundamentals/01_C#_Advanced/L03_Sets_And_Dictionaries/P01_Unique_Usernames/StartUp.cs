using System;
using System.Collections.Generic;

namespace P01_Unique_Usernames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();

            while (n-- > 0)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
