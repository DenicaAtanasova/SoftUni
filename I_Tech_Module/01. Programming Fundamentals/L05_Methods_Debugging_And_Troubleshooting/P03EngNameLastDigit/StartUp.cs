
namespace P03EngNameLastDigit
{
    using System;

    class StartUp
    {
        static string GetLastDigitInEng(long number)
        {
            
            long lastDigit = (Math.Abs(number) % 10);
            string digitInEng= "";
            switch (lastDigit)
            {
                case 0:
                    digitInEng = "zero";
                    break;
                case 1:
                    digitInEng = "one";
                    break;
                case 2:
                    digitInEng = "two";
                    break;
                case 3:
                    digitInEng = "three";
                    break;
                case 4:
                    digitInEng = "four";
                    break;
                case 5:
                    digitInEng = "five";
                    break;
                case 6:
                    digitInEng = "six";
                    break;
                case 7:
                    digitInEng = "seven";
                    break;
                case 8:
                    digitInEng = "eight";
                    break;
                case 9:
                    digitInEng = "nine";
                    break;
            }
            return digitInEng;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastDigitInEng(long.Parse(Console.ReadLine())));
        }
    }
}
