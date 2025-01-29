namespace ActDigital.Store.Core.DomainObjects;

public class Validations
{
    public static void IsEqual(object object1, object object2, string message)
    {
        if (object1.Equals(object2))
            throw new DomainException(message);
    }

    public static void IsDifferent(object object1, object object2, string message)
    {
        if (!object1.Equals(object2))
            throw new DomainException(message);
    }
    
    public static void IsGreaterThanZero(object object1, string message)
    {
        if(decimal.TryParse(object1.ToString(), out decimal resultParse) && resultParse == 0)
            throw new DomainException(message);
    }
    
    public static void IsEmpty(string valor, string message)
    {
        if (valor == null || valor.Trim().Length == 0)
            throw new DomainException(message);
    }

    public static void IsNull(object object1, string message)
    {
        if (object1 == null)
            throw new DomainException(message);
    }
    
    public static void IsGuidEmpty(Guid object1, string message)
    {
        if (object1 == null || object1 == Guid.Empty)
            throw new DomainException(message);
    }
     
    public static void HasItem<T>(ICollection<T> object1, string message)
    {
        if (object1 == null || !object1.Any())
            throw new DomainException(message);
    }
}