using BuildingBlocks.SharedKernel.Events;

namespace BuildingBlocks.SharedKernel.Entities
{
    public abstract class BaseEntity<TId>: IEquatable<BaseEntity<TId>>
    {
        public TId Id { get; protected set; } = default!;
        private readonly List<IDomainEvent> _domainEvents = [];
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        // For Object-Relational Mappers (ORMs)
        protected BaseEntity() { }
        protected BaseEntity(TId id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Id cannot be null");
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();

        public bool Equals(BaseEntity<TId>? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null || GetType() != other.GetType()) return false;
            if (IsTransient() || other.IsTransient()) return false;
            return Id!.Equals(other.Id);
        }
        public override bool Equals(object? obj) => Equals(obj as BaseEntity<TId>);
        public override int GetHashCode() => IsTransient() ? base.GetHashCode() : Id!.GetHashCode();
        public static bool operator ==(BaseEntity<TId>? left, BaseEntity<TId>? right) => left?.Equals(right) ?? right is null;
        public static bool operator !=(BaseEntity<TId>? left, BaseEntity<TId>? right) => !(left == right);
        public bool IsTransient() => EqualityComparer<TId>.Default.Equals(Id, default!);
    }
}
