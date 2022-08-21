using FluentAssertions;
using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities;
using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Specifications;
using Xunit;

namespace PowerUtils.BuildingBlocks.Domain.Tests
{
    public class SpecificationTests
    {
        [Fact]
        public void Quantity5NotDeleted_IsSatisfiedBy_True()
        {
            // Arrange
            var product = new FakeProduct(4512, 5);


            // Act
            var act = new FakeAvailableProductSpec().IsSatisfiedBy(product);


            // Assert
            act.Should()
                .BeTrue();
        }

        [Fact]
        public void Quantity0NotDeleted_IsSatisfiedBy_True()
        {
            // Arrange
            var product = new FakeProduct(4512, 0);


            // Act
            var act = new FakeAvailableProductSpec().IsSatisfiedBy(product);


            // Assert
            act.Should()
                .BeFalse();
        }

        [Fact]
        public void Quantity5Deleted_IsNotSatisfiedBy_True()
        {
            // Arrange
            var product = new FakeProduct(4512, 5);
            product.Delete();


            // Act
            var act = new FakeAvailableProductSpec().IsNotSatisfiedBy(product);


            // Assert
            act.Should()
                .BeTrue();
        }
    }
}
