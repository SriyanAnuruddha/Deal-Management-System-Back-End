using Deal_Management_System.Validations;
using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [User_RoleValidation]
        public string Role { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
