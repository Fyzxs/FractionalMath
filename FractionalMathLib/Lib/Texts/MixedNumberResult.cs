using FractionalMathLib.Results;

namespace FractionalMathLib.Lib.Texts {
    public sealed class MixedNumberResult: TextResult
    {
        private const string NoSeparator = "";
        private const string SeparatorGlyph = "_";
        private readonly TextResult _integer;
        private readonly TextResult _fraction;

        public MixedNumberResult(Result origin):this(new IntegerMixedNumberTextResult(origin), new FractionMixedNumberTextResult(origin)) { }

        private MixedNumberResult(TextResult integer, TextResult fraction)
        {
            _integer = integer;
            _fraction = fraction;
        }

        public override string AsSystemType() => $"{_integer.AsSystemType()}{Separator()}{_fraction.AsSystemType()}";

        private string Separator() => OneOfTheTwoHaveNoValue() ? NoSeparator : SeparatorGlyph;

        private bool OneOfTheTwoHaveNoValue() => 0 == _integer.AsSystemType().Length || 0 == _fraction.AsSystemType().Length;
    }
}