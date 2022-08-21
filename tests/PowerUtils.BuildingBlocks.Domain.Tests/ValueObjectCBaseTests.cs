using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects;

namespace PowerUtils.BuildingBlocks.Domain.Tests;

public class ValueObjectCBaseTests
{
    [Fact]
    public void BothNULL_EqualityOperator_True()
    {
        // Arrange
        FakeValueObjectC left = null;
        FakeValueObjectC right = null;


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
        FakeValueObjectC left = null;
        var right = new FakeValueObjectC(12, "Fake");


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
        var left = new FakeValueObjectC(12, "Fake");
        FakeValueObjectC right = null;


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void AllFieldsNull_EqualityOperator_True()
    {
        // Arrange
        var left = new FakeValueObjectC();
        var right = new FakeValueObjectC();


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void AllFieldsNull_EqualsMethod_True()
    {
        // Arrange
        var left = new FakeValueObjectC();
        var right = new FakeValueObjectC();


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void LeftFieldsNull_EqualityOperator_False()
    {
        // Arrange
        var left = new FakeValueObjectC();
        var right = new FakeValueObjectC(12, "Fake");


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void RightFieldsNull_EqualityOperator_False()
    {
        // Arrange
        var left = new FakeValueObjectC(12, "Fake");
        var right = new FakeValueObjectC();


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void LeftFieldsNull_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeValueObjectC();
        var right = new FakeValueObjectC(12, "Fake");


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void RightValueWithNullId_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeValueObjectC(12, "Fake");
        var right = new FakeValueObjectC();


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void AllFieldsDifferents_EqualityOperator_False()
    {
        // Arrange
        var left = new FakeValueObjectC(13, "Fake left");
        var right = new FakeValueObjectC(12, "Fake right");


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void AllFieldsDifferents_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeValueObjectC(13, "Fake left");
        var right = new FakeValueObjectC(12, "Fake right");


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void AllFieldAreSame_EqualityOperator_True()
    {
        // Arrange
        var left = new FakeValueObjectC(13, "Fake");
        var right = new FakeValueObjectC(13, "Fake");


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void AllFieldAreSame_EqualsMethod_True()
    {
        // Arrange
        var left = new FakeValueObjectC(13, "Fake");
        var right = new FakeValueObjectC(13, "Fake");


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void AllFieldAreDifferents_DifferenceOperator_True()
    {
        // Arrange
        var left = new FakeValueObjectC(13, "Fake left");
        var right = new FakeValueObjectC(12, "Fake right");


        // Act
        var act = left != right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void AllFieldAreSame_DifferenceOperator_False()
    {
        // Arrange
        var left = new FakeValueObjectC(13, "Fake");
        var right = new FakeValueObjectC(13, "Fake");


        // Act
        var act = left != right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void DifferentNestedValueObject_EqualityOperator_False()
    {
        // Arrange
        var left = new FakeValueObjectC(13, "Fake", 12, 13);
        var right = new FakeValueObjectC(13, "Fake", 12, 14);


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void EqualsNestedValueObject_EqualityOperator_True()
    {
        // Arrange
        var left = new FakeValueObjectC(13, "Fake", 12, 13);
        var right = new FakeValueObjectC(13, "Fake", 12, 13);


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void SameTypeAndSameValues_TestHashcode_BothEquals()
    {
        // Arrange
        var fake1 = new FakeValueObjectC(1, "fake");
        var fake2 = new FakeValueObjectC(1, "fake");


        // Act
        var act1 = fake1.GetHashCode();
        var act2 = fake2.GetHashCode();


        // Assert
        act1.Should()
            .Be(act2);
    }

    [Fact]
    public void SameTypeAndDifferentValues_TestHashcode_BothEquals()
    {
        // Arrange
        var fake1 = new FakeValueObjectC(1, "fake");
        var fake2 = new FakeValueObjectC(2, "fake");


        // Act
        var act1 = fake1.GetHashCode();
        var act2 = fake2.GetHashCode();


        // Assert
        act1.Should()
            .NotBe(act2);
    }

    [Fact]
    public void DifferentType_TestHashcode_BothEquals()
    {
        // Arrange
        var fake1 = new FakeValueObjectC(1, "fake");
        var fake2 = new FakeNestedValueObjectC(1, 2);


        // Act
        var act1 = fake1.GetHashCode();
        var act2 = fake2.GetHashCode();


        // Assert
        act1.Should()
            .NotBe(act2);
    }

    [Fact]
    public void DifferenteValueObject_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeValueObjectC(1, "fake");
        var right = new FakeNestedValueObjectC(1, 2);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }


    [Fact]
    public void RightNull_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeValueObjectC(1, "fake");
        FakeValueObjectC right = null;


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact]
    public void DifferenteClassesBothIDsNull_EqualsMethod_True()
    {
        // Arrange
        var left = new FakeValueObjectC(1, "fake");
        var right = new FakeValueObjectC(1, "fake");


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact]
    public void CompareWithNonValueObject_EqualsMethod_False()
    {
        // Arrange
        var left = new FakeValueObjectC(1, "fake");
        var right = new object();


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }
}
