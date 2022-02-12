using System;
using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities;

namespace PowerUtils.BuildingBlocks.Domain.Tests;

[Trait("Category", "Entities")]
public class EntityBaseTests
{
    [Fact(DisplayName = "Equality operator, both entities are null - Should return true")]
    public void EqualityOperator_BothNULL_True()
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

    [Fact(DisplayName = "Equality operator, only left entity is null - Should return false")]
    public void EqualityOperator_LeftNULL_False()
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

    [Fact(DisplayName = "Equality operator, only right entity is null - Should return false")]
    public void EqualityOperator_RightNULL_False()
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

    [Fact(DisplayName = "Equality operator, both entities have null Ids - Should return true")]
    public void EqualityOperator_BothIdsNULL_True()
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

    [Fact(DisplayName = "Equals method, both entities have null Ids - Should return true")]
    public void EqualsMethod_BothIdsNULL_True()
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

    [Fact(DisplayName = "Equality operator, only right entity has null Id - Should return false")]
    public void EqualityOperator_LeftIdNULL_False()
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

    [Fact(DisplayName = "Equals method, only left entity has null Id - Should return false")]
    public void EqualsMethod_LeftIdNULL_False()
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

    [Fact(DisplayName = "Equality operator, only right entity has null Id - Should return false")]
    public void EqualityOperator_RightIdNULL_False()
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

    [Fact(DisplayName = "Equals method, only right entity has null Id - Should return false")]
    public void EqualsMethod_RightIdNULL_False()
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

    [Fact(DisplayName = "Equality operator, different Ids - Should return false")]
    public void EqualityOperator_DifferentIds_False()
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

    [Fact(DisplayName = "Equals method, different Ids - Should return false")]
    public void EqualsMethod_DifferentIds_False()
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

    [Fact(DisplayName = "Equality operator, same Ids - Should return true")]
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

    [Fact(DisplayName = "Equals method, same Ids - Should return true")]
    public void EqualsMethod_SameIds_True()
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

    [Fact(DisplayName = "Equals method, classes with type Ids different - Should return false")]
    public void EqualsMethod_DifferenteClassesBothIDs12_False()
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

    [Fact(DisplayName = "Equals method, different classes and the right object is null - Should return false")]
    public void EqualsMethod_DifferenteClassesRightNull_False()
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

    [Fact(DisplayName = "Equals method, different classes and both both instanced - Should return false")]
    public void EqualsMethod_DifferenteClassesBothIDsNull_False()
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

    [Fact(DisplayName = "Difference operator, different Ids - Should return true")]
    public void DifferenceOperator_DifferentIds_True()
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

    [Fact(DisplayName = "Difference operator, same Ids - Should return false")]
    public void DifferenceOperator_SameIds_False()
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

    [Fact(DisplayName = "Comparison of the hash codes, same types and Ids - Should return true")]
    public void ComparisonHashCodes_SameTypeAndIds_True()
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

    [Fact(DisplayName = "Comparison of the hash codes, different types and same Ids - Should return false")]
    public void ComparisonHashCodes_DifferentTypeSameIds_False()
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

    [Fact(DisplayName = "Comparison of the hash codes, same types and differentT Ids - Should return false")]
    public void ComparisonHashCodes_SameTypeAndDifferentTIds_False()
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

    [Fact(DisplayName = "Test an entity valid - Should not return anything")]
    public void Validate_Valid_NoException()
    {
        // Arrange
        var fake = new FakeEntity(Guid.NewGuid(), "Fake name");


        // Act
        var act = Record.Exception(() => fake.Validate());


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact(DisplayName = "Test an entity wihtout validate setted - Should not return anything")]
    public void Validate_EntityNotSetValidate_Void()
    {
        // Arrange
        var fake = new FakeClient();


        // Act
        var act = Record.Exception(() => fake.Validate());


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact(DisplayName = "Test an entity invalid - Should return an exception")]
    public void Validate_Invalid_void()
    {
        // Arrange
        var fake = new FakeEntity(Guid.NewGuid());


        // Act
        var act = Record.Exception(() => fake.Validate());


        // Assert
        act.Should()
            .NotBeNull();
    }

    [Fact(DisplayName = "ToString of the entity - Should return a type and userId")]
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

    [Fact(DisplayName = "Test hash code of two entities with same type and same id - Should return same HashCode for both entities")]
    public void TestHashcode_SameTypeAndSameId_BothEquals()
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

    [Fact(DisplayName = "Test hash code of two entities with same type and different id - Should return different HashCode")]
    public void TestHashcode_SameTypeAndDifferentId_BothEquals()
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

    [Fact(DisplayName = "Test hash code of two entities with different type and same id - Should return different HashCode")]
    public void TestHashcode_DifferentTypeAndSameId_BothEquals()
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
