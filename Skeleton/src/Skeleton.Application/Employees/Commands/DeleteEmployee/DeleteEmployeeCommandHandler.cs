using MediatR;
using Skeleton.Application.Common.Interfaces.Persistence;
using Skeleton.Domain.Common.Exceptions.Errors;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler
    : IRequestHandler<DeleteEmployeeCommand, Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(
        IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        if (await _employeeRepository.GetById(request.Id) is not Employee employee)
        {
            throw new EmployeeNotFoundException(request.Id);
        }

        await _employeeRepository.Delete(employee.Id);

        return employee;
    }
}