using System;
using System.Collections.Generic;

namespace L06_Parking_Lot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var parkingLot = new HashSet<string>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var parkingInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var direction = parkingInfo[0];
                var carNumber = parkingInfo[1];

                switch (direction)
                {
                    case"IN":
                        parkingLot.Add(carNumber);
                        break;
                    case "OUT":
                        parkingLot.Remove(carNumber);
                        break;
                }
            }

            Console.WriteLine(parkingLot.Count == 0 ? "Parking Lot is Empty" : string.Join(Environment.NewLine, parkingLot));
        }
    }
}
