namespace Task5CharacterStats
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maximumHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maximumEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");

            Console.Write("Health: ");
            Console.Write(new string('|', currentHealth + 1));
            Console.Write(new string('.', maximumHealth - currentHealth));
            Console.WriteLine('|');

            Console.Write("Energy: ");
            Console.Write(new string('|', currentEnergy + 1));
            Console.Write(new string('.', maximumEnergy - currentEnergy));
            Console.WriteLine('|');
        }
    }
}
