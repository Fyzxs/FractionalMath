using System;
using FractionalMathLib.ExternalSource;
using FractionalMathLib.Results;

namespace FractionalMathLib.Lib.Texts
{
    public sealed class FractionMixedNumberTextResult : TextResult
    {
        private const double Tolerance = .00001;
        private const string NoFraction = "";

        private readonly Result _origin;

        public FractionMixedNumberTextResult(Result origin) => _origin = origin;

        public override string AsSystemType()
        {
            double toFraction = DecimalComponent(_origin.AsSystemType());

            if (NotFraction(toFraction)) return NoFraction;

            return FractionAsString(toFraction);
        }

        private static string FractionAsString(double toFraction) => Fractions.RealToFraction(toFraction).ToString();

        private static bool NotFraction(double toFraction) => Math.Abs(toFraction) < Tolerance;

        private static double DecimalComponent(double sourceValue) => Math.Abs(sourceValue - Math.Truncate(sourceValue));
    }
}