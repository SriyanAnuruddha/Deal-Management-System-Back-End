using Deal_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.Validations
{
    public class User_RoleValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var user = validationContext.ObjectInstance as User;

            if (user != null)
            {
                string role = user.Role;
                if (role != "admin" && role != "reporter" && user.Role != "developer")
                {
                    return new ValidationResult("Role is invalid. use a proper role");
                }
                  
            }

            return ValidationResult.Success;


        }
    }
}
