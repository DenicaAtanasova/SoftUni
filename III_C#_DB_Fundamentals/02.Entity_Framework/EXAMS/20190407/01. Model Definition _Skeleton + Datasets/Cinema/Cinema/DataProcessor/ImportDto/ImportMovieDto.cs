namespace Cinema.DataProcessor.ImportDto
{
    using Cinema.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class ImportMovieDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Title { get; set; }

        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        public string Duration { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Director { get; set; }
    }
}
