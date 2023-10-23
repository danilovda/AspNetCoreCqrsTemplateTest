using MediatR;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Queries.Get_entityTemplate_ById;

public record Get_entityTemplate_ByIdQuery(int Id) : IRequest<_entityTemplate_>;