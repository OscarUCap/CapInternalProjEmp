using System.ComponentModel.DataAnnotations;

namespace CapInternalProjEmp.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(32, ErrorMessage="No longer than 32 chars")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-.]+$", ErrorMessage = "Please Enter Valid Email")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }
        
    }
}