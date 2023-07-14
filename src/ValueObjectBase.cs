#if NET5_0_OR_GREATER

using System;

namespace PowerUtils.BuildingBlocks.Domain
{
    /// <summary>
    /// This abstraction for ".NET 5 or later" doesn't provide any additional benefit as it simply restricts the implementation of value objects to records.
    /// It's commonly recommended to use `structs`, `record structs`, and similar constructs for value object implementations.
    /// Therefore, utilizing the `IValueObjectBase` interface to indicate the implementation as a value object is more than sufficient and isn't restricted to specific implementation types.
    /// </summary>
    [Obsolete("Use the `IValueObjectBase` interface to mark your implementation as `ValueObject`. The implementation will be completely removed after 2024/01/14.")]
    public abstract record ValueObjectBase : IValueObjectBase { }
}

#else

using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerUtils.BuildingBlocks.Domain
{
    // https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    public abstract class ValueObjectBase : IValueObjectBase,
        IEquatable<ValueObjectBase>
    {
        /// <summary>
        /// Gets value that defines the object instance
        /// </summary>
        protected abstract IEnumerable<object> GetEqualityComponents();

        public virtual bool Equals(ValueObjectBase other)
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
            => Equals(obj as ValueObjectBase);

        public override int GetHashCode()
            => GetEqualityComponents()
                .Aggregate(1, (current, obj)
                    => HashCode.Combine(current, obj));

        /// <summary>
        /// Equality operator
        /// </summary>
        public static bool operator ==(ValueObjectBase left, ValueObjectBase right)
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
        public static bool operator !=(ValueObjectBase left, ValueObjectBase right)
            => !(left == right);
    }
}

#endif
