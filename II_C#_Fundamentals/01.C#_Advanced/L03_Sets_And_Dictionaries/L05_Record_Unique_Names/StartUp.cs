using System;
using System.Collections.Generic;

namespace L05_Record_Unique_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();

            while (n-- > 0)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
