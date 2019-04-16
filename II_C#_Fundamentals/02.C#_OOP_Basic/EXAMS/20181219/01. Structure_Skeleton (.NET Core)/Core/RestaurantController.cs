namespace SoftUniRestaurant.Core
{
    using Models.Drinks.Contracts;
    using Models.Foods.Contracts;
    using Models.Tables.Contracts;
    using SoftUniRestaurant.Models.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RestaurantController
    {
        private readonly List<IFood> foods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private readonly FoodFactory foodFactory;
        private readonly DrinkFactory drinkFactory;
        private readonly TableFactory tableFactory;

        private decimal totalIncome;

        public RestaurantController()
        {
            this.foods = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }

        public string AddFood(string type, string name, decimal price)
        {
            var food = this.foodFactory.Create(type, name, price);

            if (food == null)
            {
                return string.Empty;
            }

            this.foods.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drink = this.drinkFactory.Create(type, name, servingSize, brand);

            if (drink == null)
            {
                return string.Empty;
            }

            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var table = this.tableFactory.Create(type, tableNumber, capacity);

            if (table == null)
            {
                return string.Empty;
            }

            this.tables.Add(table);
            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(t => t.Capacity >= numberOfPeople && t.IsReserved == false);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);
            
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var food = this.foods.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Empty;
            }

            var bill = table.GetBill();
            this.totalIncome += bill;
            var result = $"Table: {tableNumber}" + Environment.NewLine +
                         $"Bill: {bill:f2}";

            table.Clear();

            return result;
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables
                .Where(t => t.IsReserved == false)
                .Select(t => t.GetFreeTableInfo());

            var result = string.Join(Environment.NewLine, freeTables);

            return result;
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTables = this.tables
                .Where(t => t.IsReserved == true)
                .Select(t => t.GetOccupiedTableInfo());

            var result = string.Join(Environment.NewLine, occupiedTables);

            return result;
        }

        public string GetSummary()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }
    }
}
