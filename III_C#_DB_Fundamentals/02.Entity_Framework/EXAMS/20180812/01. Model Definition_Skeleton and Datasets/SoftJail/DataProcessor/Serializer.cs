namespace SoftJail.DataProcessor
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ProjectTo<ExportPrisonerDto>()
                .ToArray();

            var jsonPrisoners = JsonConvert.SerializeObject(prisoners);

            return jsonPrisoners;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context
                .Prisoners
                .Where(p => names.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new ExportXmlPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                    .Select(m => new ExportMessageDto
                    {
                        Description = ReverseString(m.Description)
                    })
                    .ToArray()
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportXmlPrisonerDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            serializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            var result = sb.ToString();
            return result;
        }

        private static string ReverseString(string text)
        {
            return string.Join("", text.Reverse());
        }
    }
}