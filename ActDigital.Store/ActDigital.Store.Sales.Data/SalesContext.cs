using ActDigital.Store.Core.Communication.Mediator;
using ActDigital.Store.Core.Data;
using ActDigital.Store.Core.Messages;
using ActDigital.Store.Sales.Domain;
using ClassLibrary1ActDigital.Store.Sales.Data.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary1ActDigital.Store.Sales.Data;

public class SalesContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler; 
    private readonly IConfiguration _configuration; 
    
    public SalesContext()   
    {
    }

     public SalesContext(DbContextOptions<SalesContext> options, 
                         IMediatorHandler mediatorHandler,
                         IConfiguration configuration) : base(options)
     {
         _mediatorHandler = mediatorHandler;
         _configuration = configuration;
         ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
         ChangeTracker.AutoDetectChangesEnabled = false;
     }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = _configuration.GetConnectionString("DefaultConnection"); 
        optionsBuilder.UseSqlServer(conn);   

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<ProductItem> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    
    public async Task<bool> Commit()
    {
        var success = await base.SaveChangesAsync() > 0;
        
        if(success) await _mediatorHandler.PublishEvents(this);

        return success;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Event>();
        modelBuilder.ApplyConfiguration(new Map.ProductItemMap());
        modelBuilder.ApplyConfiguration(new Map.SaleMap());
        
        base.OnModelCreating(modelBuilder);
    }
}