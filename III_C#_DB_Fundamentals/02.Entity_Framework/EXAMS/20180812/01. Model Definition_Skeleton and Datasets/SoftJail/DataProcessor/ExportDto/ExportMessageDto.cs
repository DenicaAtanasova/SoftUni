namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class ExportMessageDto
    {
        public string Description { get; set; }
    }
}
