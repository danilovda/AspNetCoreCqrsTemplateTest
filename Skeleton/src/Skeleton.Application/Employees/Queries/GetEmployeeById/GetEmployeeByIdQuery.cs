using MediatR;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Queries.GetEmployeeById;

public record GetEmployeeByIdQuery(int Id) : IRequest<Employee>;