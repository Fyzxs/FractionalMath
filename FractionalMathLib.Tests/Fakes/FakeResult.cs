using FractionalMathLib.Results.Doubles;

namespace FractionalMathLib.Tests.Fakes
{
    internal sealed class FakeResult : Result
    {
        private readonly double _value;

        public FakeResult() : this(0) { }
        public FakeResult(double value) => _value = value;

        public override double AsSystemType() => _value;
    }
}