//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;

//namespace PowerUtils.BuildingBlocks.Domain
//{
//    public sealed class EntityComparer<TId> : IEqualityComparer<IEntityBase<TId>>
//    {
//        public static IEqualityComparer<IEntityBase<TId>> Default { get; set; } = new EntityComparer<TId>();

//        public bool Equals(IEntityBase<TId> left, IEntityBase<TId> right)
//            => left.Equals(right);

//        public int GetHashCode([DisallowNull] IEntityBase<TId> obj)
//            => obj.GetHashCode();
//    }
//}
