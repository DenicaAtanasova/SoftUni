namespace CosmosX.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class CommandParser : ICommandParser
    {
        private const string CommandNameSuffix = "Command";

        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments.First() + CommandNameSuffix;
            arguments.RemoveAt(0);

            var result = (string)this.reactorManager
                .GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name == command)
                .Invoke(this.reactorManager, new object[] {arguments});

            return result;
        }
    }
}