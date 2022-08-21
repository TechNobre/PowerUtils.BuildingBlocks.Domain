using System;
using System.Linq.Expressions;
using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities;

namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Specifications
{
    public class FakeAvailableProductSpec : Specification<FakeProduct>
    {
        public override Expression<Func<FakeProduct, bool>> ToExpression()
            => product => !product.Deleted
                       && product.Quantity > 0;
    }
}
