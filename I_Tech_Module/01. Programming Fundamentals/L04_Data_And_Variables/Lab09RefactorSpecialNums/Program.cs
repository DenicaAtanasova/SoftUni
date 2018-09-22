namespace Lab9RefactorSpecialNums
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int num = 1; num <= n; num++)
            {
                int digit = num;
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num = num / 10;
                }
                bool specialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{digit} -> {specialNum}");
                num = digit;
            }
        }
    }
}