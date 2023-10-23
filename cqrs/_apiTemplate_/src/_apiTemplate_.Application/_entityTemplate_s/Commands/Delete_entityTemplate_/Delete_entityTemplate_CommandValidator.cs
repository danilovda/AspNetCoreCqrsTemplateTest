using FluentValidation;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Delete_entityTemplate_;

public class Delete_entityTemplate_CommandValidator : AbstractValidator<Delete_entityTemplate_Command>
{
    public Delete_entityTemplate_CommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
