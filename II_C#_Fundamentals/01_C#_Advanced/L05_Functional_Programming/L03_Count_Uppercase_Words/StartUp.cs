using System;
using System.Linq;

namespace L03_Count_Uppercase_Words
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = s => char.IsUpper(s[0]);

            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper);

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
