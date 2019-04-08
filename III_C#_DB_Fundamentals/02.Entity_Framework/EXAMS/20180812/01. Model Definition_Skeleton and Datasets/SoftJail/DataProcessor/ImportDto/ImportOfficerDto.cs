namespace SoftJail.DataProcessor.ImportDto
{
    using SoftJail.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        //[EnumDataType(typeof(Position))]
        public string Position { get; set; }

        //[EnumDataType(typeof(Weapon))]
        public string Weapon { get; set; }

        public int DepartmentId { get; set; }

        public ImportPrisonerIdDto[] Prisoners { get; set; }
    }
}
