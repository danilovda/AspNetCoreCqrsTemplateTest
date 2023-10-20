using MediatR;
using Skeleton.Application.Common.Interfaces.Persistence;
using Skeleton.Domain.Common.Exceptions.Errors;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(
        IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> Handle(
        GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        if (await _employeeRepository.GetById(request.Id) is not Employee employee)
        {
            throw new EmployeeNotFoundException(request.Id);
        }

        return employee;
    }
}
