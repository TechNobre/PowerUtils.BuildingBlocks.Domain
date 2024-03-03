using System;

namespace PowerUtils.BuildingBlocks.Domain
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; protected set; }

        protected EntityBase() { }
        protected EntityBase(TId id)
            : this() => Id = id;


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

        public override bool Equals(object obj)
            => Equals(obj as EntityBase<TId>);

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
