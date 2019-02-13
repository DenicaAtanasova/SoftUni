using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02_Robot_Communication
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var pattern = "[,_][A-Za-z]*\\d";

            var line = string.Empty;

            while ((line = Console.ReadLine()) != "Report")
            {
                var encodedStrings = Regex.Matches(line, pattern);

                foreach (Match message in encodedStrings)
                {
                    DecodeMessage(message.Value);
                }

                Console.WriteLine();
            }
        }

        private static void DecodeMessage(string encodedMessage)
        {
            var digit = (int)char.GetNumericValue(encodedMessage.Last());
            var message = encodedMessage.TrimStart(encodedMessage[0]).TrimEnd(encodedMessage.Last());

            var decodedMessage = new StringBuilder();

            switch (encodedMessage[0])
            {
                case ',':
                    foreach (var symbol in message)
                    {
                        decodedMessage.Append(Convert.ToChar((int)symbol + digit));
                    }
                    decodedMessage.Append(" ");
                    break;
                case '_':
                    foreach (var symbol in message)
                    {
                        decodedMessage.Append(Convert.ToChar((int)symbol - digit));
                    }
                    decodedMessage.Append(" ");
                    break;
            }

            Console.Write(decodedMessage.ToString());
        }
    }
}
