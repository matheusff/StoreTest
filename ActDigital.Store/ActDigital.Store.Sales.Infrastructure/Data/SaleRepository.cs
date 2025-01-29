using ActDigital.Store.Core.Data;
using ActDigital.Store.Sales.Domain;
using ActDigital.Store.Sales.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ActDigital.Store.Sales.Infrastructure.Data;

public class SaleRepository : ISaleRepository
{
    private readonly SalesContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public SaleRepository(SalesContext context)
    {
        _context = context;
    }

    public void Save(Sale sale)
    {
        _context.Entry(sale).State = EntityState.Added;
        _context.Sales.Add(sale);
    }

    public void Update(Sale sale)
    {
        _context.Entry<Sale>(sale).State = EntityState.Modified;
        _context.Sales.Update(sale);
    }

    public async Task<Sale?> GetById(Guid id)
    {
        return await _context.Sales
            .Include(i => i.Items)
            .FirstOrDefaultAsync(item => item.Id == id);
    }

    public void Remove(Sale sale)
    {
        _context.Entry(sale).State = EntityState.Deleted;
        _context.Sales.Remove(sale);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}