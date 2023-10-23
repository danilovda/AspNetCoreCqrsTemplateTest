using MapsterMapper;
using MediatR;
using _apiTemplate_.Application.Common.Interfaces.Persistence;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Queries.GetAll_entityTemplate_s;
public class GetAll_entityTemplate_sQueryHandler
    : IRequestHandler<GetAll_entityTemplate_sQuery, IEnumerable<_entityTemplate_>>
{
    private readonly IMapper _mapper;
    private readonly I_entityTemplate_Repository __entityTemplate_Repository;

    public GetAll_entityTemplate_sQueryHandler(
        IMapper mapper,
        I_entityTemplate_Repository _entityTemplate_Repository)
    {
        _mapper = mapper;
        __entityTemplate_Repository = _entityTemplate_Repository;
    }

    public async Task<IEnumerable<_entityTemplate_>> Handle(
        GetAll_entityTemplate_sQuery request,
        CancellationToken cancellationToken)
    {
        var _entityTemplate_s = await __entityTemplate_Repository.GetAll();

        var result = _mapper.Map<IEnumerable<_entityTemplate_>>(_entityTemplate_s);
        return result.ToList();
    }
}