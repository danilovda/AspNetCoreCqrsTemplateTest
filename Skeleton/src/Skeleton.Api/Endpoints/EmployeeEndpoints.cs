using Skeleton.Api.EndpointHandlers;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Api.Endpoints;

static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");

        var employeeItems = app.MapGroup("/api/v1/employees");
        employeeItems.MapGet("/", EmployeeEndpointHandler.GetAllEmployees);
        employeeItems.MapGet("/{id}", EmployeeEndpointHandler.GetEmployeeById)
            .Produces<Employee>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
            //.WithOpenApi(opt =>
            //{
            //    opt.Description = "Get a specific employee by **id**";
            //    opt.Parameters[0].Description = "Employee id";
            //    opt.Responses[StatusCodes.Status200OK.ToString()].Description = "Success case. We found a employee with the given Id";
            //    opt.Responses[StatusCodes.Status404NotFound.ToString()].Description = "No employee found with the given Id";
            //    return opt;
            //});
        employeeItems.MapPost("/", EmployeeEndpointHandler.CreateEmployee);
        employeeItems.MapPut("/", EmployeeEndpointHandler.UpdateEmployee);
        employeeItems.MapDelete("/{id}", EmployeeEndpointHandler.DeleteEmployee);

    }
}
