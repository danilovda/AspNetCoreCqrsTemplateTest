using MediatR;
using _apiTemplate_.Application.Common.Interfaces.Persistence;
using _apiTemplate_.Domain.Common.Exceptions.Errors;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Update_entityTemplate_;

public class Update_entityTemplate_CommandHandler
    : IRequestHandler<Update_entityTemplate_Command, _entityTemplate_>
{
    private readonly I_entityTemplate_Repository __entityTemplate_Repository;

    public Update_entityTemplate_CommandHandler(
        I_entityTemplate_Repository _entityTemplate_Repository)
    {
        __entityTemplate_Repository = _entityTemplate_Repository;
    }

    public async Task<_entityTemplate_> Handle(
    Update_entityTemplate_Command request,
        CancellationToken cancellationToken)
    {
        if (await __entityTemplate_Repository.GetById(request.Id) is not _entityTemplate_ _entityTemplate_)
        {
            throw new _entityTemplate_NotFoundException(request.Id);
        }

        _entityTemplate_.FirstName = request.FirstName;
        _entityTemplate_.LastName = request.LastName;
        _entityTemplate_.MiddleName = request.MiddleName;

        await __entityTemplate_Repository.Update(_entityTemplate_);

        return _entityTemplate_;
    }
}

