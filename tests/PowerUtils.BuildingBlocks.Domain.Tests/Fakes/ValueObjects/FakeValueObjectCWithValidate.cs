using System;
using System.Collections.Generic;

namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects;

public class FakeValueObjectCWithValidate : ValueObjectCBase
{
    public string Value { get; init; }

    public FakeValueObjectCWithValidate(string value) => Value = value;

    public override void Validate()
    {
        if(string.IsNullOrWhiteSpace(Value))
        {
            throw new ArgumentException("Cannot be null or empty", nameof(Value));
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
