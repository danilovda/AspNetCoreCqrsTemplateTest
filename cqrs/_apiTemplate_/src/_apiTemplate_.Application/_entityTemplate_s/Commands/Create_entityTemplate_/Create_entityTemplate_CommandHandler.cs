using MediatR;
using _apiTemplate_.Application.Common.Interfaces.Persistence;
using _apiTemplate_.Domain._entityTemplate_Aggregate;

namespace _apiTemplate_.Application._entityTemplate_s.Commands.Create_entityTemplate_;

public class Create_entityTemplate_CommandHandler
    : IRequestHandler<Create_entityTemplate_Command, _entityTemplate_>
{
    private readonly I_entityTemplate_Repository __entityTemplate_Repository;

    public Create_entityTemplate_CommandHandler(
        I_entityTemplate_Repository _entityTemplate_Repository)
    {
        __entityTemplate_Repository = _entityTemplate_Repository;
    }

    public async Task<_entityTemplate_> Handle(
        Create_entityTemplate_Command request,
        CancellationToken cancellationToken)
    {
        var _entityTemplate_ = new _entityTemplate_()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName
        };

        var result = await __entityTemplate_Repository.Insert(_entityTemplate_);

        return result;
    }
}
