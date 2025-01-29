namespace ActDigital.Store.Core.DomainObjects;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    { }
}
