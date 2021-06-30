using FluentValidation;
using SocialApp.INFRASTRUCTURE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.API.Validators
{
    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
