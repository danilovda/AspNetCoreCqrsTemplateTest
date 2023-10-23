using MapsterMapper;
using MediatR;
using _apiTemplate_.Application._entityTemplate_s.Commands.Create_entityTemplate_;
using _apiTemplate_.Application._entityTemplate_s.Commands.Delete_entityTemplate_;
using _apiTemplate_.Application._entityTemplate_s.Commands.Update_entityTemplate_;
using _apiTemplate_.Application._entityTemplate_s.Queries.GetAll_entityTemplate_s;
using _apiTemplate_.Application._entityTemplate_s.Queries.Get_entityTemplate_ById;
using _apiTemplate_.Contracts._entityTemplate_;

namespace _apiTemplate_.Api.EndpointHandlers;

static class _entityTemplate_EndpointHandler
{
    public static async Task<IResult> GetAll_entityTemplate_s(IMapper mapper, ISender mediator)
    {
        var query = new GetAll_entityTemplate_sQuery();
        var result = await mediator.Send(query);
        var response = mapper.Map<IEnumerable<_entityTemplate_Response>>(result);
        return Results.Ok(response);
    }
    public static async Task<IResult> Get_entityTemplate_ById(IMapper mapper, ISender mediator, int id)
    {
        var query = new Get_entityTemplate_ByIdQuery(id);
        var result = await mediator.Send(query);
        var response = mapper.Map<_entityTemplate_Response>(result);
        return Results.Ok(response);
    }
    public static async Task<IResult> Create_entityTemplate_(IMapper mapper, IMediator mediator, _entityTemplate_CreateRequest request)
    {
        var command = mapper.Map<Create_entityTemplate_Command>(request);
        var result = await mediator.Send(command);
        //await mediator.Publish(new _entityTemplate_AddedNotification(result));

        var response = mapper.Map<_entityTemplate_Response>(result);
        return Results.Created($"/api/v1/_entityTemplate_s/{response.Id}", response);
    }
    public static async Task<IResult> Update_entityTemplate_(IMapper mapper, ISender mediator, _entityTemplate_UpdateRequest request)
    {
        var command = mapper.Map<Update_entityTemplate_Command>(request);
        var result = await mediator.Send(command);
        var response = mapper.Map<_entityTemplate_Response>(result);
        //return Results.NoContent();
        return Results.Ok(response);
    }
    public static async Task<IResult> Delete_entityTemplate_(ISender mediator, int id)
    {
        var command = new Delete_entityTemplate_Command(id);
        await mediator.Send(command);
        return Results.NoContent();
    }
}
