using _apiTemplate_.Domain.Common.Interfaces;

namespace _apiTemplate_.Domain._entityTemplate_Aggregate;
public class _entityTemplate_ : IAggregateRoot
{
    public int Id { get; private set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string MiddleName { get; set; } = "";
}
