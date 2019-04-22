namespace CosmosX.IO
{
    using System;
    using CosmosX.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}