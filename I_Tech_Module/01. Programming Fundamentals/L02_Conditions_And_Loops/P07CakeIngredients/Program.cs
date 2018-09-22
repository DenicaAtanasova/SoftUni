namespace Task07CakeIngredients
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string ingridient = Console.ReadLine();
            int ingridientsCount = 0;

            while (!ingridient.Equals("Bake!"))
            {
                Console.WriteLine($"Adding ingredient {ingridient}.");
                ingridientsCount++;
                ingridient = Console.ReadLine();
            }
            Console.WriteLine($"Preparing cake with {ingridientsCount} ingredients.");
        }
    }
}