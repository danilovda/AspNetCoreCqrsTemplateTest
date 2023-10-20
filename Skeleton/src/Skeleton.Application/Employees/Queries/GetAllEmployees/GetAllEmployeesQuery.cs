using MediatR;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Queries.GetAllEmployees;
public record GetAllEmployeesQuery() : IRequest<IEnumerable<Employee>>;
