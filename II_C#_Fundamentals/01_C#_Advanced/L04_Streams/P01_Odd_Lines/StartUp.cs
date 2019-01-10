using System.IO;
using System;

namespace P01_Odd_Lines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lineNummber = 1;

            var file = "../../../../Resources/text.txt";
            using (var reader = new StreamReader(file))
            {
                string line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNummber % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineNummber++;
                }
            }
        }
    }
}
