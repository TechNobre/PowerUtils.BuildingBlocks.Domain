#if NET5_0_OR_GREATER
namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects
{
    public record FakeNestedValueObjectR : ValueObjectBase
    {
        public int Value1 { get; init; }
        public int Value2 { get; init; }

        public FakeNestedValueObjectR() { }

        public FakeNestedValueObjectR(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }
}
#endif
