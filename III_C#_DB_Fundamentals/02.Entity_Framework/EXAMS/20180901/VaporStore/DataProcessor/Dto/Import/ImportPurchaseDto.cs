namespace VaporStore.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using VaporStore.Data.Models.Enums;

    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement()]
        [EnumDataType(typeof(PurchaseType))]
        public string Type { get; set; }

        [Required]
        [RegularExpression(@"^([A-Z0-9]{4}-){2}[A-Z0-9]{4}$")]
        public string Key { get; set; }

        [RegularExpression(@"^(\d{4}\s+){3}\d{4}$")]
        public string Card { get; set; }

        public string Date { get; set; }
    }
}