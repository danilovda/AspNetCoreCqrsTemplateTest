using MediatR;
using Skeleton.Application.Common.Interfaces.Persistence;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(
        IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = new Employee()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName
        };

        var result = await _employeeRepository.Insert(employee);

        return result;
    }
}
