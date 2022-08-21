namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities
{
    public class FakeCustomer : EntityBase<uint?>
    {
        public FakeCustomer() { }
        public FakeCustomer(uint? id)
           : base(id) { }
        public FakeCustomer(uint id)
            : base(id) { }
    }
}
