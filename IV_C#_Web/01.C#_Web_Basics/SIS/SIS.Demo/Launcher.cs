namespace SIS.Demo
{
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;

    public class Launcher
    {
        static void Main(string[] args)
        {
            var port = 8000;
            var serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Add(
                HttpRequestMethod.Get,
                "/",
                request => new HomeController().Index(request));

            var server = new Server(port, serverRoutingTable);

            server.Run();
        }
    }
}