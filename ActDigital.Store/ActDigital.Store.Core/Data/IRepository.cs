using ActDigital.Store.Core.DomainObjects;

namespace ActDigital.Store.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}