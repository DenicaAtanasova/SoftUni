namespace VaporStore.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Data.Models.Enums;

    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^(\d{4}\s+){3}\d{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$")]
        public string Cvc { get; set; }

        [EnumDataType(typeof(CardType))]
        public string Type { get; set; }
    }
}
