namespace ActDigital.Store.Core.Data.EventSourcing
{
    public class StoredEvent
    {
        public StoredEvent(Guid id, string type, DateTime dateAffect, string data)
        {
            Id = id;
            Type = type;
            dateAffect = dateAffect;
            Data = data;
        }

        public Guid Id { get; private set; }

        public string Type { get; private set; }

        public DateTime Date { get; set; }

        public string Data { get; private set; }
    }
}