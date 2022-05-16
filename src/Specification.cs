using System;
using System.Linq.Expressions;

namespace PowerUtils.BuildingBlocks.Domain
{
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
