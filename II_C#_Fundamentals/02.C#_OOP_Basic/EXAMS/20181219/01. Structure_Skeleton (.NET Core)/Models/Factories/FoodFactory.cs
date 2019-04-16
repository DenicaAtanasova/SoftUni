namespace SoftUniRestaurant.Models.Factories
{
    using Foods;
    using Foods.Contracts;

    public class FoodFactory
    {
        public IFood Create(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    return new Dessert(name, price);
                case "MainCourse":
                    return new MainCourse(name, price);
                case "Salad":
                    return new Salad(name, price);
                case "Soup":
                    return new Soup(name, price);
                default:
                    return null;
            }
        }
    }
}
