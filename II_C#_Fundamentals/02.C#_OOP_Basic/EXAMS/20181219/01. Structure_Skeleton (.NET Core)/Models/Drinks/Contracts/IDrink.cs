namespace SoftUniRestaurant.Models.Drinks.Contracts
{
    public interface IDrink
    {
        string Name { get; }

        string Brand { get; }

        decimal Price { get; }
    }
}
