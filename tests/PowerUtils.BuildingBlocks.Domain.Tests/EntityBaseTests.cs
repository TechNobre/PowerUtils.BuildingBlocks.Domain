using System;
using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities;

namespace PowerUtils.BuildingBlocks.Domain.Tests;

public class EntityBaseTests
{
    [Fact]
    public void BothNULL_EqualityOperator_True()
    {
        // Arrange
        FakeEntity left = null;
        FakeEntity right = null;


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void LeftNULL_EqualityOperator_False()
    {
        // Arrange
        FakeEntity left = null;

        var right = new FakeEntity
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void RightNULL_EqualityOperator_False()
    {
        // Arrange
        var left = new FakeEntity
        {
            Name = "Fake string name 1"
        };

        FakeEntity right = null;


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void BothIdsNULL_EqualityOperator_True()
    {
        // Arrange
        var left = new FakeEntity
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void BothIdsNULL_EqualsMethod_True()
    {
        // Arrange
        var left = new FakeEntity
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void LeftIdNULL_EqualityOperator_False()
    {
        // Arrange
        var left = new FakeEntity
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void LeftIdNULL_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeEntity
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void RightIdNULL_EqualityOperator_False()
    {
        // Arrange
        var left = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void RightIdNULL_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void DifferentIds_EqualityOperator_False()
    {
        // Arrange
        var left = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 2"
        };

        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void DifferentIds_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void EqualityOperator_SameIds_True()
    {
        // Arrange
        var id = Guid.NewGuid();

        var left = new FakeEntity(id)
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity(id)
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void SameIds_EqualsMethod_True()
    {
        // Arrange
        var id = Guid.NewGuid();

        var left = new FakeEntity(id)
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity(id)
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void DifferenteClassesBothIDs12_EqualsMethod_False()
    {
        // Arrange
        FakeClient left = new() { Id = 12 };
        FakeCustomer right = new() { Id = 12 };


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void DifferenteClassesRightNull_EqualsMethod_False()
    {
        // Arrange
        FakeEntity left = new();
        FakeClient right = null;


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void DifferenteClassesBothIDsNull_EqualsMethod_False()
    {
        // Arrange
        FakeClient left = new() { Id = null };
        FakeCustomer right = new() { Id = null };


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void DifferentIds_DifferenceOperator_True()
    {
        // Arrange
        var left = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity(Guid.NewGuid())
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left != right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void SameIds_DifferenceOperator_False()
    {
        // Arrange
        var id = Guid.NewGuid();

        var left = new FakeEntity(id)
        {
            Name = "Fake string name 1"
        };

        var right = new FakeEntity(id)
        {
            Name = "Fake string name 2"
        };


        // Act
        var act = left != right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void SameTypeAndIds_ComparisonHashCodes_True()
    {
        // Arrange
        var id = Guid.NewGuid();

        var entity1 = new FakeEntity(id);
        var entity2 = new FakeEntity(id);


        // Act
        var act = entity1.GetHashCode() == entity2.GetHashCode();


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void DifferentTypeSameIds_ComparisonHashCodes_False()
    {
        // Arrange
        var id = Guid.NewGuid();

        var entity1 = new FakeEntity(id);
        var entity2 = new FakeAuxEntity(id);


        // Act
        var act = entity1.GetHashCode() == entity2.GetHashCode();


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void SameTypeAndDifferentTIds_ComparisonHashCodes_False()
    {
        // Arrange
        var entity1 = new FakeEntity(Guid.NewGuid());
        var entity2 = new FakeEntity(Guid.NewGuid());


        // Act
        var act = entity1.GetHashCode() == entity2.GetHashCode();


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void Entity_ToString_WithTypeAndUserId()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var fake = new FakeEntity(userId);


        // Act
        var act = fake.ToString();


        // Assert
        act.Should()
            .Be($"[FakeEntity] Id: {userId}");
    }

    [Fact]
    public void SameTypeAndSameId_TestHashcode_BothEquals()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var fake1 = new FakeEntity(userId);
        var fake2 = new FakeEntity(userId);


        // Act
        var act1 = fake1.GetHashCode();
        var act2 = fake2.GetHashCode();


        // Assert
        act1.Should()
            .Be(act2);
    }

    [Fact]
    public void SameTypeAndDifferentId_TestHashcode_BothEquals()
    {
        // Arrange
        var fake1 = new FakeEntity(Guid.NewGuid());
        var fake2 = new FakeEntity(Guid.NewGuid());


        // Act
        var act1 = fake1.GetHashCode();
        var act2 = fake2.GetHashCode();


        // Assert
        act1.Should()
            .NotBe(act2);
    }

    [Fact]
    public void DifferentTypeAndSameId_TestHashcode_BothEquals()
    {
        // Arrange
        uint id = 451;
        var fake1 = new FakeProduct(id);
        var fake2 = new FakeCustomer(id);


        // Act
        var act1 = fake1.GetHashCode();
        var act2 = fake2.GetHashCode();


        // Assert
        act1.Should()
            .NotBe(act2);
    }
}
