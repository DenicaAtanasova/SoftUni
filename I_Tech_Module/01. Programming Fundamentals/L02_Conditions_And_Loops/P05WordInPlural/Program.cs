namespace Task05WordInPlural
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string wordInPlural = "";

            if (word.EndsWith("y"))
            {
                wordInPlural = word.Remove(word.Length - 1) + "ies";
            }
            else if (word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("s") || word.EndsWith("sh") || word.EndsWith("x") || word.EndsWith("z"))
            {
                wordInPlural = word + "es";
            } 
            else
            {
                wordInPlural = word + "s";
            }
            Console.WriteLine(wordInPlural);
        }
    }
}
