namespace SIS.WebServer.Routing
{
    using HTTP.Common;
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

        public void Add(HttpRequestMethod requestMethod, string path, Func<IHttpRequest, IHttpResponse> func)
        {
            CoreValidator.ThrowIfNull(requestMethod, nameof(requestMethod));
            CoreValidator.ThrowIfNullOrEmpty(path, nameof(path));
            CoreValidator.ThrowIfNull(func, nameof(func));

            this.routes[requestMethod].Add(path.ToLower(), func);
        }

        public bool Contains(HttpRequestMethod requestMethod, string path)
        {
            CoreValidator.ThrowIfNull(requestMethod, nameof(requestMethod));
            CoreValidator.ThrowIfNullOrEmpty(path, nameof(path));

            return this.routes.ContainsKey(requestMethod) && this.routes[requestMethod].ContainsKey(path);
        }

        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path)
        {
            CoreValidator.ThrowIfNull(requestMethod, nameof(requestMethod));
            CoreValidator.ThrowIfNullOrEmpty(path, nameof(path));

            return this.routes[requestMethod][path];
        }
    }
}