using ActDigital.Store.Core.Communication.Mediator;
using ActDigital.Store.Sales.Application.Commands;
using MediatR;

namespace ActDigital.Store.Sales.Application.Events;

public class SaleEventHandler : INotificationHandler<SaleCreatedEvent>,
                                INotificationHandler<SaleModifiedEvent>,
                                INotificationHandler<SaleCancelledEvent>,
                                INotificationHandler<ItemCancelledEvent>

{
    private readonly IMediatorHandler _mediatorHandler;

    public SaleEventHandler(IMediatorHandler mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(SaleModifiedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(SaleCancelledEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(ItemCancelledEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}