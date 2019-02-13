using System;
using System.Collections.Generic;

namespace P09_Simple_Text_Editor
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var text = string.Empty;
            var memoryText = new Stack<string>();

            while (n-- > 0)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                var args = string.Empty;

                if (input.Length > 1)
                {
                    args = input[1];
                }

                switch (command)
                {
                    case "1":
                        memoryText.Push(text);

                        text += args;

                        break;
                    case "2":
                        memoryText.Push(text);

                        int symbolsToErase = int.Parse(args);

                        if (symbolsToErase > text.Length)
                        {
                            text="";
                            break;
                        }

                        text = text.Substring(0, text.Length - symbolsToErase);

                        break;
                    case "3":
                        int index = int.Parse(args);

                        if (index <= text.Length && index > 0)
                            Console.WriteLine(text[index-1]);

                        break;
                    case "4":
                        text = memoryText.Pop();
                        break;
                }
            }
        }
    }
}
