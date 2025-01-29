using ActDigital.Store.Core.Data;

namespace ActDigital.Store.Sales.Domain.Repositories;

public interface ISaleRepository : IRepository<Sale>
{
   void Save(Sale sale);
   void Update(Sale sale);
   Task<Sale?> GetById(Guid id);
   void Remove(Sale sale);
}