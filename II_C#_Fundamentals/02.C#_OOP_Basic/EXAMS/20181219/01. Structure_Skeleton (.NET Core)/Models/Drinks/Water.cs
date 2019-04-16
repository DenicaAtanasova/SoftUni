namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal DefaultPrice = 1.50M;

        public Water(string name, int servingSize, string brand) : base(name, servingSize, DefaultPrice, brand)
        {
        }
    }
}
