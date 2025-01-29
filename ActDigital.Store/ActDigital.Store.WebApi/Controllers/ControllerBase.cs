using ActDigital.Store.Core.Communication.Mediator;
using ActDigital.Store.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ActDigital.Store.WebApi.Controllers;

public abstract class ControllerBase : Controller
{
    private readonly DomainNotificationHandler _notifications;
    protected readonly IMediatorHandler _mediatorHandler;

    protected ControllerBase(INotificationHandler<DomainNotification> notifications, 
        IMediatorHandler mediatorHandler)
    {
        _notifications = (DomainNotificationHandler)notifications;
        _mediatorHandler = mediatorHandler;
    }

    protected bool ValidOperation
        => !_notifications.HasNotifications;

    protected IEnumerable<string> GetErrorMessages
        => _notifications.GetNotifications.Select(c => c.Value);
}