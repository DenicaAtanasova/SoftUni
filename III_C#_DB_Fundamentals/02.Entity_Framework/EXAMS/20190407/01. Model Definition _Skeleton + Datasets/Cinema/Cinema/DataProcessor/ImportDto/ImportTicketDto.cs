namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        public decimal Price { get; set; }

        public int ProjectionId { get; set; }
    }
}
