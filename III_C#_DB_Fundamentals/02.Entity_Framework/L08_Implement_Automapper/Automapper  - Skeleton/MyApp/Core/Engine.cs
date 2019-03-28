
namespace MyApp.Core
{
    using Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                var inputArguments = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

                try
                {
                    var result = commandInterpreter.Read(inputArguments);
                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
