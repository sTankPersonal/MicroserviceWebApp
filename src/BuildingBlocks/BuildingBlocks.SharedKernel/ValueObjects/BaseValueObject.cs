namespace BuildingBlocks.SharedKernel.ValueObjects
{
    public abstract class BaseValueObject
    {
        private readonly IEnumerable<object>? _equalityComponents;
        protected BaseValueObject() { }
        protected BaseValueObject(IEnumerable<object> equalityComponents)
        {
            _equalityComponents = equalityComponents ?? throw new ArgumentNullException(nameof(equalityComponents));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is null || obj.GetType() != GetType()) return false;

            var other = (BaseValueObject)obj;

            using var thisValues = GetEqualityComponents().GetEnumerator();
            using var otherValues = other.GetEqualityComponents().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current?.Equals(otherValues.Current) == false)
                    return false;
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var obj in GetEqualityComponents())
                hash = HashCode.Combine(hash, obj);
            return hash;
        }
        public static bool operator ==(BaseValueObject? left, BaseValueObject? right) => left?.Equals(right) ?? right is null;
        public static bool operator !=(BaseValueObject? left, BaseValueObject? right) => !(left == right);
    }
}
