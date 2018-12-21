using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12MasterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num < n; num++)
            {
                if (IsPalindrome(num) && SumOfDigits(num) && ContainEvenDigit(num))
                {
                    Console.WriteLine(num);
                }
            }
        }
        static bool IsPalindrome(int num)
        {
            int n = num;
            int reverse = 0;
            while (num > 0)
            {
                int digit = num % 10;
                reverse = reverse * 10 + digit;
                num = num / 10;
            }
            if (n == reverse) return true;
            else return false;
        }

        static bool SumOfDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num = num / 10;
            }
            if (sum % 7 == 0) return true;
            else return false;
        }

        static bool ContainEvenDigit(int num)
        {
            while (num > 0)
            {
                if (num % 10 % 2 == 0) return true;
                num /= 10;
            }
            return false;
        }
    }
}