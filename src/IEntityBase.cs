using System;

namespace PowerUtils.BuildingBlocks.Domain
{
    public interface IEntityBase<TId> :
        IEquatable<IEntityBase<TId>>
    {
        TId Id { get; }
    }
}
