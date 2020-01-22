using FractionalMathLib.Results;
using FractionalMathLib.ToRefactor;

namespace FractionalMathLib.Lib.Texts {
    public sealed class FractionMixedNumberTextResult : TextResult
    {
        private readonly Result _origin;

        public FractionMixedNumberTextResult(Result origin) => _origin = origin;

        public override string AsSystemType()
        {
            //TODO: Still a lot of imperative code. Mostly numeric. Can 'Numbers' be created? Should they?
            double sourceValue = _origin.AsSystemType();
            int truncated = (int)sourceValue;
            double toFraction = sourceValue - truncated;
            string fractionString = Fractions.RealToFraction(toFraction).ToString();
            return fractionString;
        }
    }
}