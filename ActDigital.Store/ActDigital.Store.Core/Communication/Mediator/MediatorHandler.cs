using ActDigital.Store.Core.Data.EventSourcing;
using ActDigital.Store.Core.Messages;
using ActDigital.Store.Core.Messages.DomainEvents;
using ActDigital.Store.Core.Messages.Notifications;
using MediatR;

namespace ActDigital.Store.Core.Communication.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;
    private readonly IEventSourcingRepository _eventSourcingRepository;

    public MediatorHandler(IMediator mediator, 
                           IEventSourcingRepository eventSourcingRepository)
    {
        _mediator = mediator;
        _eventSourcingRepository = eventSourcingRepository;
    }

    public async Task PublishEvent<T>(T publishEvent) where T : Event
    {
        await _mediator.Publish(publishEvent);
        await _eventSourcingRepository.SaveEvent(publishEvent);
    }

    public async Task<bool> SendCommand<T>(T commmand) where T : Command
    {
        return await _mediator.Send(commmand);
    }

    public async Task PublishNotification<T>(T notification) where T : DomainNotification
    {
        await _mediator.Publish(notification);
    }

    public async Task PublishDomainEvent<T>(T notification) where T : DomainEvent
    {
        await _mediator.Publish(notification);
    }
}