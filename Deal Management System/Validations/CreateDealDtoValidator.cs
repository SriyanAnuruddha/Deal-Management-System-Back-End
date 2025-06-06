using Deal_Management_System.DTOs;
using FluentValidation;
using System.Data;

namespace Deal_Management_System.Validations
{
    public class CreateDealDtoValidator:AbstractValidator<CreateDealDTO>
    {
        public CreateDealDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
