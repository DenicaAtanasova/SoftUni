namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        private const decimal DefaultPrice = 3.50M;

        public Alcohol(string name, int servingSize, string brand) : base(name, servingSize, DefaultPrice, brand)
        {
        }
    }
}
