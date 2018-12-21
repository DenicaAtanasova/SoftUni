
namespace L01BlankReceipt
{
    using System;

    public class Startup
    {
        static void printHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
        static void printBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }
        static void printFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }
        public static void Main(string[] args)
        {
            printHeader();
            printBody();
            printFooter();
        }
    }
}
