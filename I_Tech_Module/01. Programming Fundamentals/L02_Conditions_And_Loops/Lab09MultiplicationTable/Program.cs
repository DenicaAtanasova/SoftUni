namespace Lab9MultiplicationTable
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int multiplier = 1;

            while (multiplier <= 10)
            {
                int product = num * multiplier;
                Console.WriteLine("{0} X {1} = {2}", num, multiplier, product);
                multiplier ++;
            }
        }
    }
}
