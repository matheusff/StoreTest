using ActDigital.Store.Core.Messages;
using ActDigital.Store.Core.Messages.DomainEvents;
using ActDigital.Store.Core.Messages.Notifications;

namespace ActDigital.Store.Core.Communication.Mediator;

public interface IMediatorHandler
{
    Task PublishEvent<T>(T publishEvent) where T : Event;
    Task<bool> SendCommand<T>(T commmand) where T : Command;
    Task PublishNotification<T>(T notification) where T : DomainNotification;
    Task PublishDomainEvent<T>(T notification) where T : DomainEvent;
}