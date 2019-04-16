namespace SoftUniRestaurant.Core
{
    using IO.Contracts;
    using System;
    using System.Linq;

    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly RestaurantController restaurantController;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.restaurantController = new RestaurantController();
        }

        public void Run()
        {
            var inputLine = string.Empty;

            while ((inputLine = reader.ReadLine()) != "END")
            { 
                try
                {
                    this.ReadCommand(inputLine);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            writer.WriteLine(this.restaurantController.GetSummary());
        }
        
        private void ReadCommand(string inputLine)
        {
            var commandArgs = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = commandArgs[0];

            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (command)
            {
                case "AddFood":
                    output = this.restaurantController.AddFood(args[0], args[1], decimal.Parse(args[2]));
                    break;
                case "AddDrink":
                    output = this.restaurantController.AddDrink(args[0], args[1], int.Parse(args[2]), args[3]);
                    break;
                case "AddTable":
                    output = this.restaurantController.AddTable(args[0], int.Parse(args[1]), int.Parse(args[2]));
                    break;
                case "ReserveTable":
                    output = this.restaurantController.ReserveTable(int.Parse(args[0]));
                    break;
                case "OrderFood":
                    output = this.restaurantController.OrderFood(int.Parse(args[0]), args[1]);
                    break;
                case "OrderDrink":
                    output = this.restaurantController.OrderDrink(int.Parse(args[0]), args[1], args[2]);
                    break;
                case "LeaveTable":
                    output = this.restaurantController.LeaveTable(int.Parse(args[0]));
                    break;
                case "GetFreeTablesInfo":
                    output = this.restaurantController.GetFreeTablesInfo();
                    break;
                case "GetOccupiedTablesInfo":
                    output = this.restaurantController.GetOccupiedTablesInfo();
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
