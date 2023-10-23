using MediatR;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Delete_entityTemplate_;

public record Delete_entityTemplate_Command(int Id) : IRequest<_entityTemplate_>;