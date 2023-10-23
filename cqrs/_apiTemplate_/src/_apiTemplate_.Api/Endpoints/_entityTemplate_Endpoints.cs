using _apiTemplate_.Api.EndpointHandlers;
using _apiTemplate_.Domain.EmployeeAggregate;

namespace _apiTemplate_.Api.Endpoints;

static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");

        var employeeItems = app.MapGroup("/api/v1/_entityTemplate_s");
        _entityTemplate_Items.MapGet("/", _entityTemplate_EndpointHandler.GetAll_entityTemplate_s);
        _entityTemplate_Items.MapGet("/{id}", _entityTemplate_EndpointHandler.Get_entityTemplate_ById)
            .Produces<_entityTemplate_>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            //.WithOpenApi(opt =>
            //{
            //    opt.Description = "Get a specific _entityTemplate_ by **id**";
            //    opt.Parameters[0].Description = "_entityTemplate_ id";
            //    opt.Responses[StatusCodes.Status200OK.ToString()].Description = "Success case. We found a _entityTemplate_ with the given Id";
            //    opt.Responses[StatusCodes.Status404NotFound.ToString()].Description = "No _entityTemplate_ found with the given Id";
            //    return opt;
            //});
        _entityTemplate_Items.MapPost("/", _entityTemplate_EndpointHandler.Create_entityTemplate_);
        _entityTemplate_Items.MapPut("/", _entityTemplate_EndpointHandler.Update_entityTemplate_);
        _entityTemplate_Items.MapDelete("/{id}", _entityTemplate_EndpointHandler.Delete_entityTemplate_);

    }
}
