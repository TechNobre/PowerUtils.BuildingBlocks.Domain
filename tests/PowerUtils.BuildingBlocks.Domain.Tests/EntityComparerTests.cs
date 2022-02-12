//using System;
//using System.Collections.Generic;
//using PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities;

//namespace PowerUtils.BuildingBlocks.Domain.Tests;

//[Trait("Category", "Entities")]
//public class EntityComparerTests
//{

//    [Fact(DisplayName = "Add two different object in dictionary - Should add successfully")]
//    public void EqualityComparer_AddDifferentObjects_Added()
//    {
//        // Arrange
//        var comparer = new EntityComparer<Guid?>();
//        var list = new Dictionary<FakeEntity, int>(comparer);

//        var fake1 = new FakeEntity(Guid.NewGuid(), "Fake name 1");
//        var fake2 = new FakeEntity(Guid.NewGuid(), "Fake name 2");


//        // Act
//        Exception act = null;
//        try
//        {
//            list.Add(fake1, 1);
//            list.Add(fake2, 2);
//        }
//        catch(Exception exception)
//        {
//            act = exception;
//        }


//        // Assert
//        act.Should()
//            .BeNull();
//    }

//    [Fact(DisplayName = "Add two different object withe the same Id in dictionary - Should return an exception")]
//    public void EqualityComparer_AddDifferentObjectsSameId_Exception()
//    {
//        // Arrange
//        var comparer = EntityComparer<Guid?>.Default;
//        var list = new Dictionary<FakeEntity, int>(comparer);

//        var id = Guid.NewGuid();

//        var fake1 = new FakeEntity(id, "Fake name 1");
//        var fake2 = new FakeEntity(id, "Fake name 2");


//        // Act
//        Exception act = null;
//        try
//        {
//            list.Add(fake1, 1);
//            list.Add(fake2, 2);
//        }
//        catch(Exception exception)
//        {
//            act = exception;
//        }


//        // Assert
//        act.Should()
//            .NotBeNull();
//    }
//}
