﻿using Deal_Management_System.DTOs;
using FluentValidation;

namespace Deal_Management_System.Validations
{
    public class UserDtoValidator:AbstractValidator<UserDTO>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("username is required!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("password is required!");
        }
    }
}
