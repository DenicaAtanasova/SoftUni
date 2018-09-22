namespace P09CountTheIntegers
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int integerCounter = 0;

            while (true)
            {
                try
                {
                    int num = int.Parse(Console.ReadLine());
                    integerCounter++;
                }
                catch (Exception)
                {
                    Console.WriteLine(integerCounter);
                    break;
                }
            }
        }
    }
}
