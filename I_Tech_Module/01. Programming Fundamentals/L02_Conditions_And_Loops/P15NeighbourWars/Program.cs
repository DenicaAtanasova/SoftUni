namespace P15NeighbourWars
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int PeshoDamage = int.Parse(Console.ReadLine());
            int GoshoDamage = int.Parse(Console.ReadLine());

            int PeshoHealth = 100;
            int GoshoHealth = 100;
            int round = 0;

            while (PeshoHealth > 0 && GoshoHealth > 0)
            {
                round++;
                if (round % 2 != 0)
                {
                    GoshoHealth -= PeshoDamage;
                    if (GoshoHealth <= 0)
                    {
                        Console.WriteLine($"Pesho won in {round}th round.");
                        break;
                    }

                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {GoshoHealth} health.");
                }
                else
                {
                    PeshoHealth -= GoshoDamage;
                    if (PeshoHealth <= 0)
                    {
                        Console.WriteLine($"Gosho won in {round}th round.");
                        break;
                    }
                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {PeshoHealth} health.");
                }
                if (round % 3 == 0)
                {
                    GoshoHealth += 10;
                    PeshoHealth += 10;
                }
            }
        }
    }
}
