namespace MusicHub.DataProcessor.ImportDtos
{
    using MusicHub.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        public string Duration { get; set; }

        public string CreatedOn { get; set; }

        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        public int? AlbumId { get; set; }

        public int WriterId { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
