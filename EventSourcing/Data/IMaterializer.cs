using EventSourcing.Events;

namespace EventSourcing.Data
{
    public interface IMaterializer<TEntity>
    {
        IMaterializer<TEntity> Apply(DomainEvent ev);

        TEntity Entity { get; }
    }
}