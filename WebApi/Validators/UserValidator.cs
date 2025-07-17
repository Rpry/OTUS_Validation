using System;
using FluentValidation;
using WebApi.Models;

namespace WebApi.Validators
{
    public class UserValidator : AbstractValidator<RegisterModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Login)
                .Must(e => Char.IsUpper(e[0]))
                .When(x=> x.Password.Length >= 9);
        }
    }
}