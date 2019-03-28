
namespace MyApp.Core
{
    using Contracts;
    using Commands.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string suffix = "Command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] InputArguments)
        {
            var commandName = InputArguments[0] + suffix;
            var commandArguments = InputArguments.Skip(1).ToArray();

            var commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
                .FirstOrDefault(t => t.Name == commandName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var constructor = commandType.GetConstructors().First();

            var constructorParameters = constructor
                .GetParameters()
                .Select(cp => cp.ParameterType)
                .ToArray();

            var services = constructorParameters
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)constructor
                .Invoke(services);

            var result = command.Execute(commandArguments);
            return result;
        }
    }
}
