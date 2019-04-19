namespace MusicHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        //TODO check if is required
        [RegularExpression(@"[A-Z][a-z]+ [A-Z][a-z]+")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359( \d{3}){3}$")]
        public string PhoneNumber { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
