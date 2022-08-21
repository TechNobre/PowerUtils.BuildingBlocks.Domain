using System;

namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities
{
    public class FakeEntity : EntityBase<Guid?>
    {
        public string Name { get; set; }

        public FakeEntity()
            : base()
        { }

        public FakeEntity(Guid id)
            : base(id)
        { }

        public FakeEntity(Guid id, string name)
            : base(id)
            => Name = name;
    }
}
