namespace Skeleton.Domain.Common.Exceptions;

public abstract class NotFoundException : ApplicationException
{
    protected NotFoundException(string message)
        : base("Not Found", message)
    {
    }
}
