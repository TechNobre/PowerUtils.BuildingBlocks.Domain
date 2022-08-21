#if !NET5_0_OR_GREATER
using System.Collections.Generic;

namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects
{
    public class FakeNestedValueObjectC : ValueObjectBase
    {
        public int Value1 { get; private set; }
        public int Value2 { get; private set; }

        public FakeNestedValueObjectC() { }

        public FakeNestedValueObjectC(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value1;
            yield return Value2;
        }
    }
}
#endif
