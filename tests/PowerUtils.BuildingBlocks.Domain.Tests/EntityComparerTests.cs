using System;
using System.Collections.Generic;
using FluentAssertions;
using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities;
using Xunit;

namespace PowerUtils.BuildingBlocks.Domain.Tests
{
    public class EntityComparerTests
    {

        [Fact]
        public void AddDifferentObjects_EqualityComparer_Added()
        {
            // Arrange
            var comparer = new EntityComparer<Guid?>();
            var list = new Dictionary<FakeEntity, int>(comparer);

            var fake1 = new FakeEntity(Guid.NewGuid(), "Fake name 1");
            var fake2 = new FakeEntity(Guid.NewGuid(), "Fake name 2");


            // Act
            var act = Record.Exception(() =>
            {
                list.Add(fake1, 1);
                list.Add(fake2, 2);
            });


            // Assert
            act.Should()
                .BeNull();
        }

        [Fact]
        public void AddDifferentObjectsSameId_EqualityComparer_Exception()
        {
            // Arrange
            var comparer = EntityComparer<Guid?>.Default;
            var list = new Dictionary<FakeEntity, int>(comparer);

            var id = Guid.NewGuid();

            var fake1 = new FakeEntity(id, "Fake name 1");
            var fake2 = new FakeEntity(id, "Fake name 2");


            // Act
            var act = Record.Exception(() =>
            {
                list.Add(fake1, 1);
                list.Add(fake2, 2);
            });


            // Assert
            act.Should()
                .NotBeNull();
        }
    }
}
