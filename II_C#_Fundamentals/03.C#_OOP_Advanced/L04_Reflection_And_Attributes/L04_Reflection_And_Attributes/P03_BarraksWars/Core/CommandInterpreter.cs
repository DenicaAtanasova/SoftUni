
namespace P03_BarraksWars.Core
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core;
    using P03_BarraksWars.Attributes;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name.ToLower() == commandName + Suffix);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var commandParams = new object[] {data};
            var command = (IExecutable)Activator.CreateInstance(commandType, commandParams);

            var fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttributes(false).Any(attr => attr.GetType() == typeof(InjectAttribute)));

            foreach (var field in fieldsToInject)
            {
                var fieldValue = this
                    .GetType()
                    .GetField(field.Name, BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(this);
;

                field.SetValue(command, fieldValue);
            }

            return command;
        }
    }
}
