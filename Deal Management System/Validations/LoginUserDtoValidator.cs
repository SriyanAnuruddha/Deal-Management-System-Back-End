using Deal_Management_System.DTOs;
using FluentValidation;

namespace Deal_Management_System.Validations
{
    public class LoginUserDtoValidator:AbstractValidator<LoginUserDTO>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("username is required!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("password is required!");
        }
    }
}
