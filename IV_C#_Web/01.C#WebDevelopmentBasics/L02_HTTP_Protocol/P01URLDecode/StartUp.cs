
namespace P01URLDecode
{
    using System;
    using System.Net;

    class StartUp
    {
        static void Main(string[] args)
        {
            string encodedURL = Console.ReadLine();
            string decodedURL = WebUtility.UrlDecode(encodedURL);
            Console.WriteLine(decodedURL);
        }
    }
}
