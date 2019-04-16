namespace SoftUniRestaurant.Models.Factories
{
    using Tables;
    using Tables.Contracts;

    public class TableFactory
    {
        public ITable Create(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    return new InsideTable(tableNumber, capacity);
                case "Outside":
                    return new OutsideTable(tableNumber, capacity);
                default:
                   return null;
            }
        }
    }
}
