namespace CosmosX.Entities.Reactors.ReactorFactory
{
    using CosmosX.Entities.Containers.Contracts;
    using Reactors.Contracts;
    using Contracts;
    using System.Reflection;
    using System.Linq;
    using System;

    public class ReactorFactory : IReactorFactory
    {
        private readonly string suffix = "Reactor";

        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == reactorTypeName + suffix);

            var reactor = (IReactor)Activator.CreateInstance(type, id, moduleContainer, additionalParameter);

            return reactor;
        }
    }
}
