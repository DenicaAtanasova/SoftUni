namespace P09ReverseCharacters
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            char letter1 = char.Parse(Console.ReadLine());
            char letter2 = char.Parse(Console.ReadLine());
            char letter3 = char.Parse(Console.ReadLine());

            Console.WriteLine("{2}{1}{0}", letter1,letter2,letter3);
        }
    }
}
