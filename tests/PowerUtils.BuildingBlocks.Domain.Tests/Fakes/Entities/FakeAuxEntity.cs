using System;

namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities
{
    public class FakeAuxEntity : EntityBase<Guid>
    {
        public string Name { get; set; }

        public FakeAuxEntity()
            : base()
        { }

        public FakeAuxEntity(Guid id) : base(id)
        { }
    }
}
