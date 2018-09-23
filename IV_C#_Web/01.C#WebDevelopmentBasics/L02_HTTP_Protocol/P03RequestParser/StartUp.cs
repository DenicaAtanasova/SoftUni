
namespace P03RequestParser
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            string response = "{0} {1} {2}" + Environment.NewLine +
                              "Content-Length: {3}" + Environment.NewLine +
                              "Content-Type: text/plain" + Environment.NewLine +
                              Environment.NewLine +
                              "{4}";

            Dictionary<string, HashSet<string>> validRequests = new Dictionary<string, HashSet<string>>()
                {
                    {"post", new HashSet<string>()},
                    {"get", new HashSet<string>()}
                };

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string path = input.Split('/')[1];
                string method = input.Split('/')[2];

                validRequests[method].Add(path);
            }

            var request = Console.ReadLine().Split();

            string requestMethod = request[0].Trim().ToLower();
            string requestPath = request[1].TrimStart('/');
            string requestProtocol = request[2].Trim();

            bool isValidRequest = validRequests.ContainsKey(requestMethod) &&
                                  validRequests[requestMethod].Contains(requestPath);

            if (isValidRequest)
            {
                string statusCode = "200";
                string status = "OK";

                Console.WriteLine(response, requestProtocol, statusCode, status, status.Length, status);
            }
            else
            {
                string statusCode = "404";
                string status = "NotFound";

                Console.WriteLine(response, requestProtocol, statusCode, status, status.Length, status);
            }
        }
    }
}
