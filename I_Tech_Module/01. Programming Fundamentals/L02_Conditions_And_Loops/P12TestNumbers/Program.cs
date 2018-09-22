namespace P12TestNumbers
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int sumBoundery = int.Parse(Console.ReadLine());

            int sum = 0;
            int combinationCounter = 0;
           
            for (int i = firstNum; i >= 1; i--)
            {
                if (sum > sumBoundery)
                {
                    break;
                }
                else
                {
                    for (int j = 1; j <= secondNum; j++)
                    {
                        sum = sum + 3 * (i * j);
                        combinationCounter++;
                        if (sum > sumBoundery)
                        {
                            break;
                        }
                    }
                }
            }

            if (sum >= sumBoundery)
            {
                Console.WriteLine($"{combinationCounter} combinations");
                Console.WriteLine($"Sum: {sum} >= {sumBoundery}");
            }
            else
            {
                Console.WriteLine($"{combinationCounter} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
