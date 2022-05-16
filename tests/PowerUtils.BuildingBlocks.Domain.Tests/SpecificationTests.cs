using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities;
using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Specifications;

namespace PowerUtils.BuildingBlocks.Domain.Tests;

public class SpecificationTests
{
    [Fact]
    public void IsSatisfiedBy_Quantity5NotDeleted_True()
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
    public void IsSatisfiedBy_Quantity0NotDeleted_True()
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
    public void IsNotSatisfiedBy_Quantity5Deleted_True()
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
