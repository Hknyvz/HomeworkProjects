using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateTechnologyCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateTechnologyCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}
