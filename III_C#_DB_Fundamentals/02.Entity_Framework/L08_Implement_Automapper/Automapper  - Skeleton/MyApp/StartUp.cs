
namespace MyApp
{
    using AutoMapper;
    using Core.Contracts;
    using Core;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddDbContext<MyAppContext>(sc => sc.UseSqlServer(Configuration.ConnectionString))
                .AddTransient<ICommandInterpreter, CommandInterpreter>()
                .AddTransient<Mapper>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
