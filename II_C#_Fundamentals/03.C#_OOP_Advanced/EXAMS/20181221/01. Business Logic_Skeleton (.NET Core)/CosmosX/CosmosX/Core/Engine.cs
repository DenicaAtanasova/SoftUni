namespace CosmosX.Core
{
    using Core.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;
        private bool isRunning;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            //this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                var inputLine = this.reader
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (inputLine.First() == "Exit")
                {
                    this.isRunning = false;
                }

                try
                {
                    var result = this.commandParser.Parse(inputLine);
                    this.writer.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }
        }
    }
}