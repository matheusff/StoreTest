﻿using MediatR;

namespace ActDigital.Store.Core.Messages.DomainEvents;

public abstract class DomainEvent : Message, INotification
{
    public DateTime Timestamp { get; private set; }

    protected DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
        Timestamp = DateTime.Now;
    }
}