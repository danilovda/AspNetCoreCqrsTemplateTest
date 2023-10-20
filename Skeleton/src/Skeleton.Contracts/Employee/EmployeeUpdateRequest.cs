namespace Skeleton.Contracts.Employee;
public record EmployeeUpdateRequest(
    int Id,
    string FirstName,
    string LastName,
    string MiddleName
    );
