using MediatR;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Create_entityTemplate_;

public record Create_entityTemplate_Command(
    string FirstName,
    string LastName,
    string MiddleName = ""
    ) : IRequest<_entityTemplate_>;