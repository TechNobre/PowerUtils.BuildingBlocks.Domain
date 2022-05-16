namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.Entities;

public class FakeProduct : EntityBase<uint?>
{
    public uint Quantity { get; private set; }
    public bool Deleted { get; private set; }

    public FakeProduct(uint id)
        : base(id) { }

    public FakeProduct(uint id, uint quantity)
        : this(id)
        => Quantity = quantity;

    public void Delete()
        => Deleted = true;
}
