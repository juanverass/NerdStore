using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.DomainObjects
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            var compare = obj as EntityBase;

            if (ReferenceEquals(this, compare)) return true;
            if (ReferenceEquals(null, compare)) return false;

            return Id.Equals(compare.Id);
        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
