using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerUtils.BuildingBlocks.Domain
{
    // https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    public abstract class ValueObjectCBase : IValueObjectBase,
        IEquatable<ValueObjectCBase>
    {
        /// <summary>
        /// Gets value that defines the object instance
        /// </summary>
        protected abstract IEnumerable<object> GetEqualityComponents();

        public virtual void Validate() { }

        public virtual bool Equals(ValueObjectCBase other)
        {
            if(other == null)
            {
                return false;
            }

            if(GetType() != other.GetType())
            {
                return false;
            }

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override bool Equals(object obj)
            => Equals(obj as ValueObjectCBase);

        public override int GetHashCode()
            => GetEqualityComponents()
                .Aggregate(1, (current, obj)
                     => HashCode.Combine(current, obj));

        /// <summary>
        /// Equality operator
        /// </summary>
        public static bool operator ==(ValueObjectCBase left, ValueObjectCBase right)
        {
            if(left is null && right is null)
            {
                return true;
            }

            if(left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        public static bool operator !=(ValueObjectCBase left, ValueObjectCBase right)
            => !(left == right);
    }
}
