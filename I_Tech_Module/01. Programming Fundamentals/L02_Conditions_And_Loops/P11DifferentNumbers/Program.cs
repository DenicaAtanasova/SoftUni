namespace P115DifferentNumbers
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            if (Math.Abs(firstNum - secondNum) < 4)
            {
                Console.WriteLine("No");
            }
            else
            { 
                for (int i = firstNum; i < secondNum; i++)
                {
                    for (int j = i; j < secondNum; j++)
                    {
                        for (int k = j; k < secondNum; k++)

                        {
                            for (int l = k; l < secondNum; l++)
                            {
                                for (int m = l + 1; m <= secondNum; m++)
                                {
                                    if (firstNum <= i && i < j && j < k && k < l && m <= secondNum)
                                    {
                                        Console.WriteLine($"{i} {j} {k} {l} {m}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
