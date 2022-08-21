using System;

namespace PowerUtils.BuildingBlocks.Domain
{
    public interface IEntityBase<TId> :
        IEquatable<IEntityBase<TId>>
    {
#if NET5_0_OR_GREATER
        TId Id { get; init; }
#else
        TId Id { get; }
#endif
    }
}
