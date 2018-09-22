namespace P10CenturiesToNanosecs
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            ulong minutes = 60 * (ulong)hours;
            ulong seconds = 60 * minutes;
            ulong milliseconds = 1000 * seconds;
            ulong microseconds = 1000 * milliseconds;
            double nanoseconds = 1000 * (double)microseconds;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds:F0} nanoseconds");
        }
    }
}
