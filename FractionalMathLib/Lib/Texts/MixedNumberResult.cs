using FractionalMathLib.Results;

namespace FractionalMathLib.Lib.Texts {
    public sealed class MixedNumberResult: TextResult
    {
        private readonly TextResult _integer;
        private readonly TextResult _fraction;

        public MixedNumberResult(Result origin):this(new IntegerMixedNumberTextResult(origin), new FractionMixedNumberTextResult(origin)) { }

        private MixedNumberResult(TextResult integer, TextResult fraction)
        {
            _integer = integer;
            _fraction = fraction;
        }

        public override string AsSystemType() => $"{_integer.AsSystemType()}{_fraction.AsSystemType()}";
    }
}