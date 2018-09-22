namespace P13GameOfNumbers
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int combinationCounter = 0;
            int lastFirstNum = 0;
            int lastSecodNum = 0;
            bool isFound = false;

            for (int i = firstNum; i <= secondNum; i++)
            {
                for (int j = firstNum; j <= secondNum; j++)
                {
                    if (i + j == magicNum)
                    {
                        lastFirstNum = i;
                        lastSecodNum = j;
                        isFound = true;
                    }
                    combinationCounter++;
                }                               
            }
            if (isFound)
            {
                Console.WriteLine($"Number found! {lastFirstNum} + {lastSecodNum} = {magicNum}");
            }
            else
            {
                Console.WriteLine($"{combinationCounter} combinations - neither equals {magicNum}");
            }
        }
    }
}