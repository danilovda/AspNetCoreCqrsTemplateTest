namespace _apiTemplate_.Domain.Common.Exceptions.Errors;

public sealed class _entityTemplate_NotFoundException : NotFoundException
{
    public _entityTemplate_NotFoundException(int _entityTemplate_Id)
        : base($"The _entityTemplate_ with the identifier {_entityTemplate_Id} was not found.")
    //"The _entityTemplate_ not is registered in the database"
    {
    }
}
