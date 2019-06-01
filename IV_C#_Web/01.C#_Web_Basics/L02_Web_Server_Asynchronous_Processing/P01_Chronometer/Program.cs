namespace P01_Chronometer
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "exit")
            {
                var result = chronometer
                    .GetType()
                    .GetMethod(Char.ToUpper(command[0]) + command.Substring(1))
                    .Invoke(chronometer, null);

                if (result == null)
                    continue;

                Console.WriteLine(result);
            }
        }
    }
}
