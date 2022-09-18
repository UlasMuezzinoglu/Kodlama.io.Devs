using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developer.Commands.RegisterCommand
{
    public class RegisterDeveloperValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterDeveloperValidator()
        {
            RuleFor(d => d.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(d => d.Password).NotEmpty().NotNull().Length(8, 25).WithMessage("Password must be length min 8 and max 25");
            RuleFor(d => d.FirstName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(d => d.LastName).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
