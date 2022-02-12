using System;

namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects;

public record FakeValueObjectRWithValidate : ValueObjectRBase
{
    public string Value { get; init; }

    public FakeValueObjectRWithValidate(string value)
        => Value = value;

    public override void Validate()
    {
        if(string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("Cannot be null or empty", nameof(Value));
        }
    }
}
