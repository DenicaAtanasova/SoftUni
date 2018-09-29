
namespace P02ValidateURL
{
    using System;
    using System.Net;
    using System.Text;

    class StartUp
    {
        static void Main(string[] args)
        {
            string encodedURL = Console.ReadLine();
            string decodedURL = WebUtility.UrlDecode(encodedURL);

            bool isValidURL = Uri.TryCreate(decodedURL, UriKind.Absolute, out var uriResult) && (
                (uriResult.Scheme == Uri.UriSchemeHttp && uriResult.Port == 80) || 
                (uriResult.Scheme == Uri.UriSchemeHttps && uriResult.Port == 443));

            if (!isValidURL)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                var result = new StringBuilder();

                var protocol = uriResult.Scheme;
                var path = uriResult.AbsolutePath;
                var query = uriResult.Query.TrimStart('?');
                var fragment = uriResult.Fragment.TrimStart('#');

                result.Append("Protocol: " + protocol + Environment.NewLine +
                              "Host: " + uriResult.Host + Environment.NewLine +
                              "Port: " + uriResult.Port + Environment.NewLine +
                              "Path: " + path);

                if (query != "")
                {
                    result.Append(Environment.NewLine + "Query: " + query);
                }

                if (fragment != "")
                {
                    result.Append(Environment.NewLine + "Fragment: " + fragment);
                }

                Console.WriteLine(result);
            }          
        }
    }
}
