namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var blackBoxType = typeof(BlackBoxInteger);
            var blackBox = Activator.CreateInstance(blackBoxType, true);

            var line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                var inputArguments = line.Split("_", StringSplitOptions.RemoveEmptyEntries);
                var methodName = inputArguments[0];
                var number = int.Parse(inputArguments[1]);

                var blackBoxMethod = blackBoxType
                    .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
                
                blackBoxMethod.Invoke(blackBox, new object[] { number });

                var innerValuefield = blackBoxType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                var value = innerValuefield.GetValue(blackBox);

                Console.WriteLine(value);
            }
        }
    }
}
