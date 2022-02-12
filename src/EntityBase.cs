namespace PowerUtils.BuildingBlocks.Domain
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
#if NET5_0_OR_GREATER
        public virtual TId Id { get; init; }
#else
        public virtual TId Id { get; protected set; }
#endif

        protected EntityBase() { }
        protected EntityBase(TId id)
            : this() => Id = id;

        public virtual void Validate() { }


        public virtual bool Equals(IEntityBase<TId> other)
        {
            if(other is null)
            {
                return false;
            }

            if(Id is null && other.Id is null)
            {
                return true;
            }

            if(Id is null || other.Id is null)
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public override bool Equals(object other)
            => Equals(other as EntityBase<TId>);

        /// <summary>
        /// Equality operator
        /// </summary>
        public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
        {
            if(left is null && right is null)
            {
                return true;
            }

            if(left is null || right is null)
            {
                return false;
            }

            if(left.Id is null && right.Id is null)
            {
                return true;
            }

            if(left.Id is null || right.Id is null)
            {
                return false;
            }

            return left.Id.Equals(right.Id);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
            => !(left == right);

        public override int GetHashCode()
            => System.HashCode.Combine(GetType(), Id);

        public override string ToString()
            => $"[{GetType().Name}] Id: {Id}";
    }
}
