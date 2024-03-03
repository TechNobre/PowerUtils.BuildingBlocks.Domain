using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PowerUtils.BuildingBlocks.Domain
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public sealed class EntityComparer<TId> : IEqualityComparer<IEntityBase<TId>>
    {
        public static IEqualityComparer<IEntityBase<TId>> Default { get; set; } = new EntityComparer<TId>();

        public bool Equals(IEntityBase<TId> left, IEntityBase<TId> right)
            => left.Equals(right);

        public int GetHashCode([DisallowNull] IEntityBase<TId> obj)
            => obj.GetHashCode();
    }
}
