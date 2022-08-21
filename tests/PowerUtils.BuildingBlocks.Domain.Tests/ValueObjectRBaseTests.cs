#if NET5_0_OR_GREATER
using FluentAssertions;
using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects;
using Xunit;

namespace PowerUtils.BuildingBlocks.Domain.Tests
{
    public class ValueObjectRBaseTests
    {
        [Fact]
        public void BothNULL_EqualityOperator_True()
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

        [Fact]
        public void LeftNULL_EqualityOperator_False()
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

        [Fact]
        public void RightNULL_EqualityOperator_False()
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

        [Fact]
        public void AllFieldsNull_EqualityOperator_True()
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

        [Fact]
        public void AllFieldsNull_EqualsMethod_True()
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

        [Fact]
        public void LeftFieldsNull_EqualityOperator_False()
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

        [Fact]
        public void RightFieldsNull_EqualityOperator_False()
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

        [Fact]
        public void LeftFieldsNull_EqualsMethod_False()
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

        [Fact]
        public void RightValues_EqualsMethod_NotSetted()
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

        [Fact]
        public void AllFieldsDifferents_EqualityOperator_False()
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

        [Fact]
        public void AllFieldsDifferents_EqualsMethod_False()
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

        [Fact]
        public void AllFieldAreSame_EqualityOperator_True()
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

        [Fact]
        public void AllFieldAreSame_EqualsMethod_True()
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

        [Fact]
        public void AllFieldAreDifferents_DifferenceOperator_True()
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

        [Fact]
        public void AllFieldAreSame_DifferenceOperator_False()
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

        [Fact]
        public void DifferentNestedValueObject_EqualityOperator_False()
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

        [Fact]
        public void EqualsNestedValueObject_EqualityOperator_True()
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
    }
}
#endif
