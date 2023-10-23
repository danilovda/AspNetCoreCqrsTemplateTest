using FluentValidation;

namespace _apiTemplate_.Application._entityTemplate_s.Queries.Get_entityTemplate_ById;

public class Get_entityTemplate_ByIdQueryValidator : AbstractValidator<Get_entityTemplate_ByIdQuery>
{
    public Get_entityTemplate_ByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}