using Deal_Management_System.DTOs;
using FluentValidation;

namespace Deal_Management_System.Validations
{
    public class AssignHotelsDtoValidator:AbstractValidator<AssignHotelsDTO>
    {
        public AssignHotelsDtoValidator()
        {
            RuleFor(x => x.HotelIds)
                .NotNull().WithMessage("IDs list must not be null.")
                .NotEmpty().WithMessage("IDs list must not be empty.");

            RuleForEach(x => x.HotelIds)
                .Must(id => id != Guid.Empty)
                .WithMessage("Each ID must be a valid, non-empty GUID.");
        }
    }
}
