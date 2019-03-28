
namespace FastFood.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterEmployeeInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(18, 60)]
        public int Age { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
