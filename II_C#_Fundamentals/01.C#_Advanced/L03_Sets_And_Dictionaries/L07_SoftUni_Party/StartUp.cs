using System;
using System.Collections.Generic;

namespace L07_SoftUni_Party
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var guests = new HashSet<String>();
            var vipGuests = new HashSet<String>();

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (vipGuests.Contains(input))
                {
                    vipGuests.Remove(input);
                }
                else if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
            }

            Console.WriteLine(vipGuests.Count + guests.Count);

            if (vipGuests.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuests));
            }

            if (guests.Count != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, guests));
            }
        }
    }
}
