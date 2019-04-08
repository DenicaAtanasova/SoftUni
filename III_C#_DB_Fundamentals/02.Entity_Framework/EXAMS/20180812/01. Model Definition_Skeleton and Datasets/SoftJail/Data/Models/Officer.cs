namespace SoftJail.Data.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FullName { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Salary { get; set; }

        public Position Position { get; set; }

        public Weapon Weapon { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
