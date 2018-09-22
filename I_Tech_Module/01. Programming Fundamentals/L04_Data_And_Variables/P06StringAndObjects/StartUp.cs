namespace P06StringAndObjects
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string text1 = "Hello";
            string text2 = "World";
            object concText = text1 + " " + text2;
            string text3 = (string)concText;
            Console.WriteLine(text3);
        }
    }
}
