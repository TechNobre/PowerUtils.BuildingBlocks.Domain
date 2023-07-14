#if NET5_0_OR_GREATER
namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects
{
    public record FakeValueObjectR : IValueObjectBase
    {
        public int Number { get; init; }
        public string Text { get; init; }
        public FakeNestedValueObjectR Nested { get; init; }

        public FakeValueObjectR() =>
            Nested = new FakeNestedValueObjectR();

        public FakeValueObjectR(int number, string text)
            : this()
        {
            Number = number;
            Text = text;
        }

        public FakeValueObjectR(int number, string text, int value1, int value2)
        {
            Number = number;
            Text = text;
            Nested = new FakeNestedValueObjectR(value1, value2);
        }
    }
}
#endif
