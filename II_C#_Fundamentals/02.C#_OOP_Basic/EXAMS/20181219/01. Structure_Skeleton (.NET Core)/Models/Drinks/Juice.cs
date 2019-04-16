namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice : Drink
    {
        private const decimal DefaultPrice = 1.80M;

        public Juice(string name, int servingSize, string brand) : base(name, servingSize, DefaultPrice, brand)
        {
        }
    }
}
