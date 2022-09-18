using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developer.Commands.LoginCommand
{
    public class LoginDeveloperValidator : AbstractValidator<LoginCommand>
    {
        public LoginDeveloperValidator()
        {
            RuleFor(d => d.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(d => d.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}
