using MapsterMapper;
using MediatR;
using Skeleton.Application.Employees.Commands.CreateEmployee;
using Skeleton.Application.Employees.Commands.DeleteEmployee;
using Skeleton.Application.Employees.Commands.UpdateEmployee;
using Skeleton.Application.Employees.Queries.GetAllEmployees;
using Skeleton.Application.Employees.Queries.GetEmployeeById;
using Skeleton.Contracts.Employee;

namespace Skeleton.Api.EndpointHandlers;

static class EmployeeEndpointHandler
{
    public static async Task<IResult> GetAllEmployees(IMapper mapper, ISender mediator)
    {
        var query = new GetAllEmployeesQuery();
        var result = await mediator.Send(query);
        var response = mapper.Map<IEnumerable<EmployeeResponse>>(result);
        return Results.Ok(response);
    }
    public static async Task<IResult> GetEmployeeById(IMapper mapper, ISender mediator, int id)
    {
        var query = new GetEmployeeByIdQuery(id);
        var result = await mediator.Send(query);
        var response = mapper.Map<EmployeeResponse>(result);
        return Results.Ok(response);
    }
    public static async Task<IResult> CreateEmployee(IMapper mapper, IMediator mediator, EmployeeCreateRequest request)
    {
        var command = mapper.Map<CreateEmployeeCommand>(request);
        var result = await mediator.Send(command);
        //await mediator.Publish(new EmployeeAddedNotification(result));

        var response = mapper.Map<EmployeeResponse>(result);
        return Results.Created($"/api/v1/employees/{response.Id}", response);
    }
    public static async Task<IResult> UpdateEmployee(IMapper mapper, ISender mediator, EmployeeUpdateRequest request)
    {
        var command = mapper.Map<UpdateEmployeeCommand>(request);
        var result = await mediator.Send(command);
        var response = mapper.Map<EmployeeResponse>(result);
        //return Results.NoContent();
        return Results.Ok(response);
    }
    public static async Task<IResult> DeleteEmployee(ISender mediator, int id)
    {
        var command = new DeleteEmployeeCommand(id);
        await mediator.Send(command);
        return Results.NoContent();
    }
}
