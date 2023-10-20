using MediatR;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Commands.UpdateEmployee;

public record UpdateEmployeeCommand(
    int Id,
    string FirstName,
    string LastName,
    string MiddleName
    ) : IRequest<Employee>;