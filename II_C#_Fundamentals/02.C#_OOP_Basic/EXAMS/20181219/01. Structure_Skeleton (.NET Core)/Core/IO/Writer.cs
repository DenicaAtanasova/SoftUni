namespace SoftUniRestaurant.Core.IO
{
    using Contracts;
    using System;

    class Writer : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
