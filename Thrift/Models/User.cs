using System.ComponentModel.DataAnnotations;

namespace Thrift.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public List <UserRole> UserRoles { get; set; }


    }
}
