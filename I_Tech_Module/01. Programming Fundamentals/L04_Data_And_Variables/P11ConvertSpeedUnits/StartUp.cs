namespace P11ConvertSpeedUnits
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            float distance = float.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float metersPerSeconds = distance / (hours * 3600 + minutes * 60 + seconds);
            float kilometersPerHour = (distance / 1000) / (hours + minutes / 60F + seconds / 3600F);
            float milesPerHour = (distance / 1609F) / (hours + minutes / 60F + seconds / 3600F);

            Console.WriteLine("{0}", metersPerSeconds);
            Console.WriteLine("{0}", kilometersPerHour);
            Console.WriteLine("{0}", milesPerHour);
        }
    }
}
