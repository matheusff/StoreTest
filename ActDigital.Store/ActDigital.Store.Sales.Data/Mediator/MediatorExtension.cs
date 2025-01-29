using ActDigital.Store.Core.Communication.Mediator;
using ActDigital.Store.Core.DomainObjects;

namespace ClassLibrary1ActDigital.Store.Sales.Data.Mediator;

public static class MediatorExtension
{
    public static async Task PublishEvents(this IMediatorHandler mediator, SalesContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.Notifications)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearEvents());

        //publish notifications
        var tasks = domainEvents
            .Select(async (domainEvent) => {
                await mediator.PublishEvent(domainEvent);
            });

        await Task.WhenAll(tasks);
    }
}