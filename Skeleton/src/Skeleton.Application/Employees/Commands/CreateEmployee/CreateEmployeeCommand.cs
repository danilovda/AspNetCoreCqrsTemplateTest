using MediatR;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string MiddleName = ""
    ) : IRequest<Employee>;