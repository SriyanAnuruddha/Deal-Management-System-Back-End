using Deal_Management_System.DTOs;
using FluentValidation;

namespace Deal_Management_System.Validations
{
    public class UpdateDealDetailsDtoValidator:AbstractValidator<UpdateDealDetailsDto>
    {
        public UpdateDealDetailsDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("deal name is required");

            RuleFor(x => x.VideoFile)
                .NotNull().WithMessage("video file is required!");
        }
    }
}
