using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Employees
{
    public class RegisterEmployeeInputModel
    {
        [StringLength(30, MinimumLength = 3), Required]
        public string Name { get; set; }

        [Range(15, 80), Required]
        public int Age { get; set; }

        [Required]
        public int PositionId { get; set; }

        public string PositionName { get; set; }

        [StringLength(30, MinimumLength = 3), Required]
        public string Address { get; set; }
    }
}
