namespace SIS.MvcFramework
{
    using Routing;

    public interface IMvcApplication
    {
        void ConfigureServices();
        void Configure(IServerRoutingTable serverRoutingTable);
    }
}