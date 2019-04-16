namespace SoftUniRestaurant.Models.Factories
{
    using Drinks.Contracts;
    using Drinks;

    public class DrinkFactory
    {
        public IDrink Create(string type, string name, int servingSize, string brand)
        {
            switch (type)
            {
                case "FuzzyDrink":
                    return new FuzzyDrink(name, servingSize, brand);
                case "Juice":
                    return new Juice(name, servingSize, brand);
                case "Water":
                    return new Water(name, servingSize, brand);
                case "Alcohol":
                    return new Alcohol(name, servingSize, brand);
                default:
                    return null;
            }
        }
    }
}
