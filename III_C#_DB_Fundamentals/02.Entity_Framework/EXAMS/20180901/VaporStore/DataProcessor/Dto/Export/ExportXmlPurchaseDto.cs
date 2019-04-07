namespace VaporStore.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ExportXmlPurchaseDto
    {
        public string Card { get; set; }

        public string Cvc { get; set; }

        public string Date { get; set; }

        public ExportXmlGameDto Game { get; set; }
    }
}
