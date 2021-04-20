using FluentValidation;
using SocialApp.INFRASTRUCTURE.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.API.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).MinimumLength(8);
            RuleFor(x => x.FirstName).NotNull().MinimumLength(1);
            RuleFor(x => x.LastName).NotNull().MinimumLength(1);
        }
    }
}
