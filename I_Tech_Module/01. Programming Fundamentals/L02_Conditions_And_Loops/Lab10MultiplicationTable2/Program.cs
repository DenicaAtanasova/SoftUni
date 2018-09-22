namespace Lab10MultiplicationTable2
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            do
            {
                int product = num * multiplier;
                Console.WriteLine("{0} X {1} = {2}", num, multiplier, product);
                multiplier++;
            } while (multiplier <= 10);
        }
    }
}
