namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using AutoMapper.QueryableExtensions;
    using Cinema.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using System.Text;
    using System.Xml;
    using System.IO;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var topMovies = context
                .Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count >= 1))
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Take(10)
                .ProjectTo<ExportMovieDto>()
                .ToArray();

            var jsonString = JsonConvert.SerializeObject(topMovies);
            return jsonString;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .Where(c => c.Age >= age)
                .OrderByDescending(c => c.Tickets.Sum(t => t.Price))
                .Take(10)
                .ProjectTo<ExportCustomerWithSpendingsDto>()
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportCustomerWithSpendingsDto[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            var result = sb.ToString();
            return result;
        }
    }
}