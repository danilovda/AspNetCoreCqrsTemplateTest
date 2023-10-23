using MediatR;
using _apiTemplate_.Application.Common.Interfaces.Persistence;
using _apiTemplate_.Domain.Common.Exceptions.Errors;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Queries.Get_entityTemplate_ById;

public class Get_entityTemplate_ByIdQueryHandler : IRequestHandler<Get_entityTemplate_ByIdQuery, _entityTemplate_>
{
    private readonly I_entityTemplate_Repository __entityTemplate_Repository;

    public Get_entityTemplate_ByIdQueryHandler(
        I_entityTemplate_Repository _entityTemplate_Repository)
    {
        __entityTemplate_Repository = _entityTemplate_Repository;
    }

    public async Task<_entityTemplate_> Handle(
        Get_entityTemplate_ByIdQuery request,
        CancellationToken cancellationToken)
    {
        if (await __entityTemplate_Repository.GetById(request.Id) is not _entityTemplate_ _entityTemplate_)
        {
            throw new _entityTemplate_NotFoundException(request.Id);
        }

        return _entityTemplate_;
    }
}
