namespace VaporStore.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportXmlUserDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        public ExportXmlPurchaseDto[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }
    }
}
