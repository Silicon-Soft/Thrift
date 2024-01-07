using System.ComponentModel.DataAnnotations;

namespace CrudEmployee.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Maximum 20 digit")]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public double Salary { get; set; }
    }
}
