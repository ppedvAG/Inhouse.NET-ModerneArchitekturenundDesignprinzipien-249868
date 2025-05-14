using EventSourcing.Events;

namespace EventSourcing.Data;

public class InMemoryEventStore<TEntity, TMaterializer> 
    where TEntity : class
    where TMaterializer : class, IMaterializer<TEntity>, new()
{
    // 1. Events InMemory speichern
    private readonly Dictionary<Guid, SortedList<DateTime, DomainEvent>> _eventStore = new();

    public void Append(DomainEvent domainEvent)
    {
        if (!_eventStore.ContainsKey(domainEvent.StreamId))
        {
            _eventStore[domainEvent.StreamId] = [];
        }
        domainEvent.CreatedAtUtc = DateTime.UtcNow;
        _eventStore[domainEvent.StreamId].Add(domainEvent.CreatedAtUtc, domainEvent);

        // 3. Projektion aufbauen
        var entityId = domainEvent.StreamId;
        _projections[entityId] = GetEntity(entityId);
    }

    // 2. Entity aus Events materialisieren
    public TEntity? GetEntity(Guid id)        
    {
        if (!_eventStore.ContainsKey(id))
        {
            return null;
        }

        var materializer = _eventStore[id].Aggregate(new TMaterializer(),
            (creator, pair) => (TMaterializer)creator.Apply(pair.Value));

        return materializer.Entity;
    }

    // 3. Projektionen
    // Hinweis: strong consistancy vs. eventual consistancy
    private readonly Dictionary<Guid, TEntity> _projections = new();

    public TEntity? GetEntityProjection(Guid id)
    {
        return _projections.GetValueOrDefault(id);
    }
}