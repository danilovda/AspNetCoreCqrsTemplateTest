using MediatR;
using _apiTemplate_.Application.Common.Interfaces.Persistence;
using _apiTemplate_.Domain.Common.Exceptions.Errors;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Delete_entityTemplate_;

public class Delete_entityTemplate_CommandHandler
    : IRequestHandler<Delete_entityTemplate_Command, _entityTemplate_>
{
    private readonly I_entityTemplate_Repository __entityTemplate_Repository;

    public Delete_entityTemplate_CommandHandler(
        I_entityTemplate_Repository _entityTemplate_Repository)
    {
        __entityTemplate_Repository = _entityTemplate_Repository;
    }

    public async Task<_entityTemplate_> Handle(
        Delete_entityTemplate_Command request,
        CancellationToken cancellationToken)
    {
        if (await __entityTemplate_Repository.GetById(request.Id) is not _entityTemplate_ _entityTemplate_)
        {
            throw new _entityTemplate_NotFoundException(request.Id);
        }

        await __entityTemplate_Repository.Delete(_entityTemplate_.Id);

        return _entityTemplate_;
    }
}