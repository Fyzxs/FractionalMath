using FractionalMathLib.Results;

namespace FractionalMathLib.Lib.Texts {
    public sealed class IntegerMixedNumberTextResult : TextResult
    {
        private const string NoInteger = "";

        private readonly Result _origin;

        public IntegerMixedNumberTextResult(Result origin) => _origin = origin;
        public override string AsSystemType()
        {
            int truncated = (int)_origin.AsSystemType();
            return NoIntValue(truncated) ? NoInteger : truncated.ToString();
        }

        private static bool NoIntValue(int truncated) => 0 == truncated;
    }
}