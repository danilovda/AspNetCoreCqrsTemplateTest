using MediatR;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Update_entityTemplate_;

public record Update_entityTemplate_Command(
    int Id,
    string FirstName,
    string LastName,
    string MiddleName
    ) : IRequest<_entityTemplate_>;