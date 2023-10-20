using MapsterMapper;
using MediatR;
using Skeleton.Application.Common.Interfaces.Persistence;
using Skeleton.Domain.EmployeeAggregate;

namespace Skeleton.Application.Employees.Queries.GetAllEmployees;
public class GetAllEmployeesQueryHandler
    : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesQueryHandler(
        IMapper mapper,
        IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>> Handle(
        GetAllEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAll();

        var result = _mapper.Map<IEnumerable<Employee>>(employees);
        return result.ToList();
    }
}