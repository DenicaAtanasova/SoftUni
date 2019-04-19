namespace MusicHub.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ImportAlbumDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        public string ReleaseDate { get; set; }
    }
}
