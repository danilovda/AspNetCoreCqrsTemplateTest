namespace Skeleton.Domain.Common.Exceptions.Errors;

public sealed class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(int employeeId)
        : base($"The employee with the identifier {employeeId} was not found.")
    //"The employee not is registered in the database"
    {
    }
}
