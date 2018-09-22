namespace P14MagicLetter
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char skipLetter = char.Parse(Console.ReadLine());

            for (int i = firstLetter; i <= secondLetter; i++)
            {
                for (int j = firstLetter; j <= secondLetter; j++)
                {
                    for (int k = firstLetter; k <= secondLetter; k++)
                    {
                        if ((char)i != skipLetter && (char)j != skipLetter && (char)k != skipLetter)
                        {
                            Console.Write("{0}{1}{2} ", (char)i, (char)j, (char)k);
                        }
                    }
                }
            }
        }
    }
}
