using Deal_Management_System.Validations;
using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [User_RoleValidation]
        public string Role { get; set; }
    }
}
