namespace VaporStore.DataProcessor.Dto.Import
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportUserDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        [MinLength(1)]
        public List<ImportCardDto> Cards { get; set; }
    }
}