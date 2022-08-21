#if !NET5_0_OR_GREATER
using System.Collections.Generic;

namespace PowerUtils.BuildingBlocks.Domain.Tests.Fakes.ValueObjects
{
    public class FakeValueObjectC : ValueObjectBase
    {
        public int Number { get; private set; }
        public string Text { get; private set; }
        public FakeNestedValueObjectC Nested { get; private set; }

        public FakeValueObjectC() =>
            Nested = new FakeNestedValueObjectC();

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
            Nested = new FakeNestedValueObjectC(value1, value2);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return Text;
            yield return Nested;
        }
    }
}
#endif
