using System;
using System.Linq.Expressions;

namespace PowerUtils.BuildingBlocks.Domain
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public abstract class Specification<T>
    {
        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public bool IsNotSatisfiedBy(T entity)
            => !IsSatisfiedBy(entity);

        public abstract Expression<Func<T, bool>> ToExpression();
    }

}
