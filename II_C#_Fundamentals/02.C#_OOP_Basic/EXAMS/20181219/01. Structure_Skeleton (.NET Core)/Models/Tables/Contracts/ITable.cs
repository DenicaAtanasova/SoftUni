namespace SoftUniRestaurant.Models.Tables.Contracts
{
    using Drinks.Contracts;
    using Foods.Contracts;

    public interface ITable
    {
        int Capacity { get; }

        bool IsReserved { get; }

        int TableNumber { get; }

        decimal PricePerPerson { get; }

        void Reserve(int numberOfPeople);

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();

        string GetOccupiedTableInfo();
    }
}
