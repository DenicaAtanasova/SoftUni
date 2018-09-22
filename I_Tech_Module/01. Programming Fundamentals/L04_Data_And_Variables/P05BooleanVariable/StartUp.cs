namespace P05BooleanVariable
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            bool textToBool = Convert.ToBoolean(text);
            if (textToBool)
            {
                Console.WriteLine("Yes");
            }
           else if (!textToBool)
            {
                Console.WriteLine("No");
            }
        }
    }
}