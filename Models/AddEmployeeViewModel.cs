using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApp.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]*$",ErrorMessage ="Please enter valid First Name")]
        public string firstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Please enter valid Last Name")]
        public string lastName { get; set; }
    }
}
