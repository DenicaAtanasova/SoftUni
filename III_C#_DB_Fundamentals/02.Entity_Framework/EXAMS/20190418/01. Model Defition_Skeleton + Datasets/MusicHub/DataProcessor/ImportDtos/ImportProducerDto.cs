﻿namespace MusicHub.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ImportProducerDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"[A-Z][a-z]+ [A-Z][a-z]+")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359( \d{3}){3}$")]
        public string PhoneNumber { get; set; }

        public ImportAlbumDto[] Albums { get; set; }
    }
}
