using MediatR;

namespace ActDigital.Store.Core.Messages.Notifications;

public class DomainNotification : Message, INotification
{
    public DateTime NotificationDate { get; private set; }
    public Guid DomainNotificationId { get; private set; }
    public string Key { get; private set; }
    public string Value { get; private set; }
    public int Version { get; private set; }

    public DomainNotification(string key, string value)
    {
        NotificationDate = DateTime.Now;
        DomainNotificationId = Guid.NewGuid();
        Version = 1;
        Key = key;
        Value = value;
    }
}