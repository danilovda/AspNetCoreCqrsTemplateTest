using MediatR;
using Skeleton.Application.Common.Interfaces.Persistence;
using Skeleton.Domain.Common.Exceptions.Errors;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler
    : IRequestHandler<UpdateEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(
        IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> Handle(
    UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        if (await _employeeRepository.GetById(request.Id) is not Employee employee)
        {
            throw new EmployeeNotFoundException(request.Id);
        }

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.MiddleName = request.MiddleName;

        await _employeeRepository.Update(employee);

        return employee;
    }
}

