using MediatR;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(int Id) : IRequest<Employee>;