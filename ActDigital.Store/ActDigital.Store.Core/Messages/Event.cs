using MediatR;

namespace ActDigital.Store.Core.Messages;

public abstract class Event : Message, INotification
{
    public DateTime EventDate { get; private set; }

    protected Event()
    {
        EventDate = DateTime.Now;
    }
}