using System.Text.Json;
using ActDigital.Store.Core.Data.EventSourcing;
using ActDigital.Store.Core.Messages;
using EventStore.Client;

namespace EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService;

        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        public async Task SaveEvent<TEvent>(TEvent evento) where TEvent : Event
        {
            // await _eventStoreService.GetConnection().AppendToStreamAsync(
            //     evento.AggregateId.ToString(),
            //     ExpectedVersion.Any,
            //     FormatEvent(evento));
            await Task.CompletedTask;
        }

        public Task<IEnumerable<StoredEvent>> GetEvents(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<EventData> FormatEvent<TEvent>(TEvent evento) where TEvent : Event
        {
            var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes( evento );
            
            yield return new EventData(
                Uuid.NewUuid(),
                nameof(TEvent),
                utf8Bytes.AsMemory(),
                null);
        }
    }

    internal class BaseEvent
    {
        public DateTime Timestamp { get; set; }
    }
}