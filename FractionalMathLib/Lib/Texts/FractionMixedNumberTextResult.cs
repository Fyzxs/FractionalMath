using System;
using FractionalMathLib.Results;
using FractionalMathLib.ToRefactor;

namespace FractionalMathLib.Lib.Texts
{
    public sealed class FractionMixedNumberTextResult : TextResult
    {
        private readonly Result _origin;

        public FractionMixedNumberTextResult(Result origin) => _origin = origin;

        public override string AsSystemType()
        {
            //Not 100% happy with this. I don't need "number" objects yet, though "Result" kinda is.
            double sourceValue = _origin.AsSystemType();
            double toFraction = sourceValue - Math.Truncate(sourceValue);
            return Fractions.RealToFraction(toFraction).ToString();
        }
    }
}