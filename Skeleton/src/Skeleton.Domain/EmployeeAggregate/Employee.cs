using Skeleton.Domain.Common.Interfaces;

namespace Skeleton.Domain.EmployeeAggregate;
public class Employee : IAggregateRoot
{
    public int Id { get; private set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string MiddleName { get; set; } = "";
}
