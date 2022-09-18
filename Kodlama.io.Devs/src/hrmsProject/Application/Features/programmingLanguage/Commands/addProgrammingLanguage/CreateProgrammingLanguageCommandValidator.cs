using Application.Features.programmingLanguage.addProgrammingLanguage;
using FluentValidation;

namespace Application.Features.programmingLanguage.Commands.addProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            //RuleFor(c => c.Name).SetValidator(new RegularExpressionValidator<CreateProgrammingLanguageCommand>(RegexConstants.BLACK_LIST));
        }
    }
}
