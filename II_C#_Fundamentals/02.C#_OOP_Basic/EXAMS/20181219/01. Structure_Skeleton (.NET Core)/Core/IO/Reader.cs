namespace SoftUniRestaurant.Core.IO
{
    using SoftUniRestaurant.Core.IO.Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
