namespace Skeleton.Contracts.Employee;
public record EmployeeResponse(
    int Id,
    string FirstName,
    string LastName,
    string MiddleName
    );