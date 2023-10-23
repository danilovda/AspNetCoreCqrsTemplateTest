using MediatR;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Queries.GetAll_entityTemplate_s;
public record GetAll_entityTemplate_sQuery() : IRequest<IEnumerable<_entityTemplate_>>;
