using BlogProjectOnion.Application.DTOs.AppUserDto;
using BlogProjectOnion.Application.VMs;
using BlogProjectOnion.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.FluentValidation
{
    public class UserValidator:AbstractValidator<AppUser>
    {
    }
    public class LoginUserValidator : AbstractValidator<UserLoginVM>
    {
        public LoginUserValidator()
        {


            RuleFor(x => x.Email)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(100)
             .WithName("Email");

            RuleFor(x => x.Password)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(100)
             .WithName("Parola");

        }

    }
    public class RegisterUserValidator : AbstractValidator<CreateUserDto>
    {
        public RegisterUserValidator()
        {

            RuleFor(x => x.EMail)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(100)
             .WithName("Email");

            RuleFor(x => x.Password)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(100)
             .WithName("Parola");




        }

    }
}
