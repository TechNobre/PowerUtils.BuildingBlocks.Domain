using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects;

namespace PowerUtils.BuildingBlocks.Domain.Tests;

[Trait("Category", "ValueObjects")]
public class ValueObjectRBaseTests
{
    [Fact(DisplayName = "Equality operator, both value objects are null - Should return true")]
    public void EqualityOperator_BothNULL_True()
    {
        // Arrange
        FakeValueObjectR left = null;
        FakeValueObjectR right = null;


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Equality operator, only left value object is null - Should return false")]
    public void EqualityOperator_LeftNULL_False()
    {
        // Arrange
        FakeValueObjectR left = null;
        var right = new FakeValueObjectR(12, "Fake");


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equality operator, only right value object is null - Should return false")]
    public void EqualityOperator_RightNULL_False()
    {
        // Arrange
        var left = new FakeValueObjectR(12, "Fake");
        FakeValueObjectR right = null;


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equality operator, all fiels are null - Should return true")]
    public void EqualityOperator_AllFieldsNull_True()
    {
        // Arrange
        var left = new FakeValueObjectR();
        var right = new FakeValueObjectR();


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Equals method, all fiels are null - Should return true")]
    public void EqualsMethod_AllFieldsNull_True()
    {
        // Arrange
        var left = new FakeValueObjectR();
        var right = new FakeValueObjectR();


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Equality operator, only left fiels are null - Should return false")]
    public void EqualityOperator_LeftFieldsNull_False()
    {
        // Arrange
        var left = new FakeValueObjectR();
        var right = new FakeValueObjectR(12, "Fake");


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equality operator, only right fiels are null - Should return false")]
    public void EqualityOperator_RightFieldsNull_False()
    {
        // Arrange
        var left = new FakeValueObjectR(12, "Fake");
        var right = new FakeValueObjectR();


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equals method, only left fiels are null - Should return false")]
    public void EqualsMethod_LeftFieldsNull_False()
    {
        // Arrange
        var left = new FakeValueObjectR();
        var right = new FakeValueObjectR(12, "Fake");


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equals method, only right fiels are null - Should return false")]
    public void EqualsMethod_RightValues_NotSetted()
    {
        // Arrange
        var left = new FakeValueObjectR(12, "Fake");
        var right = new FakeValueObjectR();


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equality operator, all fiels are differents - Should return false")]
    public void EqualityOperator_AllFieldsDifferents_False()
    {
        // Arrange
        var left = new FakeValueObjectR(13, "Fake left");
        var right = new FakeValueObjectR(12, "Fake right");


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equals method, all fiels are differents - Should return false")]
    public void EqualsMethod_AllFieldsDifferents_False()
    {
        // Arrange
        var left = new FakeValueObjectR(13, "Fake left");
        var right = new FakeValueObjectR(12, "Fake right");


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equality operator, all fields are the same - Should return true")]
    public void EqualityOperator_AllFieldAreSame_True()
    {
        // Arrange
        var left = new FakeValueObjectR(13, "Fake");
        var right = new FakeValueObjectR(13, "Fake");


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Equals method, all fields are the same - Should return true")]
    public void EqualsMethod_AllFieldAreSame_True()
    {
        // Arrange
        var left = new FakeValueObjectR(13, "Fake");
        var right = new FakeValueObjectR(13, "Fake");


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Difference operator, all fields are different - Should return true")]
    public void DifferenceOperator_AllFieldAreDifferents_True()
    {
        // Arrange
        var left = new FakeValueObjectR(13, "Fake left");
        var right = new FakeValueObjectR(12, "Fake right");


        // Act
        var act = left != right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Difference operator, all fields are the same - Should return false")]
    public void DifferenceOperator_AllFieldAreSame_False()
    {
        // Arrange
        var left = new FakeValueObjectR(13, "Fake");
        var right = new FakeValueObjectR(13, "Fake");


        // Act
        var act = left != right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Conpare value object with different nested value object - Should return false")]
    public void EqualityOperator_DifferentNestedValueObject_False()
    {
        // Arrange
        var left = new FakeValueObjectR(13, "Fake", 12, 13);
        var right = new FakeValueObjectR(13, "Fake", 12, 14);


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Conpare value object with equals nested value object - Should return true")]
    public void EqualityOperator_EqualsNestedValueObject_True()
    {
        // Arrange
        var left = new FakeValueObjectR(13, "Fake", 12, 13);
        var right = new FakeValueObjectR(13, "Fake", 12, 13);


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Test an ValueObject valid - Should not return anything")]
    public void Validate_Valid_NoException()
    {
        // Arrange
        var fake = new FakeValueObjectRWithValidate("Fake");


        // Act
        var act = Record.Exception(() => fake.Validate());


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact(DisplayName = "Test an ValueObject wihtout validate setted - Should not return anything")]
    public void Validate_EntityNotSetValidate_Void()
    {
        // Arrange
        var fake = new FakeValueObjectR(13, "Fake");


        // Act
        var act = Record.Exception(() => fake.Validate());


        // Assert
        act.Should()
            .BeNull();
    }

    [Fact(DisplayName = "Test an ValueObject invalid - Should return an exception")]
    public void Validate_Invalid_void()
    {
        // Arrange
        var fake = new FakeValueObjectRWithValidate(null);


        // Act
        var act = Record.Exception(() => fake.Validate());


        // Assert
        act.Should()
            .NotBeNull();
    }

}
