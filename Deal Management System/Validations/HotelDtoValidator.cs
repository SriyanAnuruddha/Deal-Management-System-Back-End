using Deal_Management_System.DTOs;
using FluentValidation;

namespace Deal_Management_System.Validations
{
    public class HotelDtoValidator:AbstractValidator<HotelDTO>
    {
        public HotelDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Rate).NotEmpty().InclusiveBetween(1.0m,5.0m).PrecisionScale(2,1,false);
            RuleFor(x => x.Amenities)
                    .Must(a => a.Contains(',') && a.Split(',').All(s => !string.IsNullOrWhiteSpace(s)))
                    .WithMessage("Amenities must be a comma separated list with no empty values.");
        }
    }
}
