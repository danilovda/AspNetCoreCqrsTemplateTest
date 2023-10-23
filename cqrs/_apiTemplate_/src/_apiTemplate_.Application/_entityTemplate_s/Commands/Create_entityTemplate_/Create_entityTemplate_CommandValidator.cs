using FluentValidation;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Create_entityTemplate_;

public class Create_entityTemplate_CommandValidator : AbstractValidator<Create_entityTemplate_Command>
{
    public Create_entityTemplate_CommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.MiddleName).NotNull();
    }
}