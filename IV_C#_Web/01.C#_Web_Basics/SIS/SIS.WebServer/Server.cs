namespace SIS.WebServer
{
    using Routing.Contracts;
    using SIS.HTTP.Common;
    using System;
    using System.Net;
    using System.Net.Sockets;

    public class Server
    {
        public const string LocalhostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IServerRoutingTable serverRoutingTable;

        private bool isRunning;

        public Server(int port, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);

            this.serverRoutingTable = serverRoutingTable;
        }
        private void Listen(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.serverRoutingTable);
            connectionHandler.ProcessRequest();
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this.port}");

            while (isRunning)
            {
                Console.WriteLine("Waiting for client...");

                var client = this.listener.AcceptSocket();

                this.Listen(client);
            }
        }
    }
}