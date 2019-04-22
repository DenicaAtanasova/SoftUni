namespace CosmosX.IO
{
    using System;
    using CosmosX.IO.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}