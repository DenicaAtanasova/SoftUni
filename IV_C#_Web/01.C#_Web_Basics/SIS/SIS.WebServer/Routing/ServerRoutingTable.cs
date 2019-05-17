namespace SIS.WebServer.Routing
{
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class ServerRoutingTable : IServerRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>> routes;

        public ServerRoutingTable()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>
            {
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }

        public void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func) =>
            this.routes[method].Add(path.ToLower(), func);

        public bool Contains(HttpRequestMethod requestMethod, string path) =>
            this.routes.ContainsKey(requestMethod) && this.routes[requestMethod].ContainsKey(path.ToLower());

        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path) =>
            this.routes[requestMethod][path.ToLower()];
    }
}
