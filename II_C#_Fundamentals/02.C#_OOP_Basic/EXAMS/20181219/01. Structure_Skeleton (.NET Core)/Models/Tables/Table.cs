namespace SoftUniRestaurant.Models.Tables
{
    using Drinks.Contracts;
    using Foods.Contracts;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Table : ITable
    {
        private readonly List<IFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public IReadOnlyCollection<IFood> FoodOrders => this.foodOrders.AsReadOnly();

        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders.AsReadOnly();

        public int TableNumber { get; }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                //TODO check if have to be <=
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            var bill = this.FoodOrders.Sum(f => f.Price) + this.DrinkOrders.Sum(f => f.Price) + this.NumberOfPeople * this.PricePerPerson;

            return bill;
        }

        public string GetFreeTableInfo()
        {
            var info = $"Table: {this.TableNumber}" + Environment.NewLine +
                       $"Type: {this.GetType().Name}" + Environment.NewLine +
                       $"Capacity: {this.Capacity}" + Environment.NewLine +
                       $"Price per Person: {this.PricePerPerson}";

            return info;
        }

        public string GetOccupiedTableInfo()
        {
            var foodOrders = "Food orders: None";
            if(this.FoodOrders.Any())
            {
                foodOrders = $"Food orders: {this.FoodOrders.Count}"  + Environment.NewLine +
                             string.Join(Environment.NewLine, this.FoodOrders);
            }

            var drinkOrders = "Drink orders: None";
            if (this.DrinkOrders.Any())
            {
                drinkOrders = $"Drink orders: {this.DrinkOrders.Count}" + Environment.NewLine +
                             string.Join(Environment.NewLine, this.DrinkOrders);
            }

            var foodCount = this.FoodOrders.Any() ? $"{this.FoodOrders.Count}" : "None";
            var drinkCount = this.drinkOrders.Any() ? $"{this.drinkOrders.Count}" : "None";

            var info = $"Table: {this.TableNumber}" + Environment.NewLine +
                       $"Type: {this.GetType().Name}" + Environment.NewLine +
                       $"Number of people: {this.NumberOfPeople}" + Environment.NewLine +
                       foodOrders + Environment.NewLine +
                       drinkOrders;

            return info;
        }

        public void OrderDrink(IDrink drink)
        {
           this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.numberOfPeople = numberOfPeople;       
        }
    }
}
