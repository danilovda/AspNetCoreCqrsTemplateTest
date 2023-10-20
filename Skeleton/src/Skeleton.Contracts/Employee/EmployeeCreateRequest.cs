namespace Skeleton.Contracts.Employee;
public record EmployeeCreateRequest(
    string FirstName,
    string LastName,
    string? MiddleName
    );