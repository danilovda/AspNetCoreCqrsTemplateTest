using FluentValidation;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Update_entityTemplate_;

public class Update_entityTemplate_CommandValidator : AbstractValidator<Update_entityTemplate_Command>
{
    public Update_entityTemplate_CommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.MiddleName).NotNull();
    }
}