using System.Collections.Generic;

namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects;

public class FakeValueObjectC : ValueObjectCBase
{
    public int Number { get; init; }
    public string Text { get; init; }
    public FakeNestedValueObjectR Nested { get; init; }

    public FakeValueObjectC() =>
        Nested = new FakeNestedValueObjectR();

    public FakeValueObjectC(int number, string text)
        : this()
    {
        Number = number;
        Text = text;
    }

    public FakeValueObjectC(int number, string text, int value1, int value2)
    {
        Number = number;
        Text = text;
        Nested = new FakeNestedValueObjectR(value1, value2);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
        yield return Text;
        yield return Nested;
    }
}
