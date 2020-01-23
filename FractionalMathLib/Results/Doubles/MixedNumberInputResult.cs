using System.Linq;

namespace FractionalMathLib.Results.Doubles {
    internal sealed class MixedNumberInputResult : Result 
    { 
        //Note: This class feels busy. Tried to refactor a few times, it has high cohesion

        private const char MixedSeparator = '_';
        private const char FractionSeparator = '/';
        private const int MixedPartsWholeIndex = 0;
        private const int MixedPartsFractionIndex = 1;

        private readonly string _origin;

        public MixedNumberInputResult(string origin) => _origin = origin;

        public override double AsSystemType() => Whole() + Fraction();

        private double Whole()
        {
            if (NotMixedNumber() && HasFraction()) return 0;
            if (NotMixedNumber() && NoFraction()) return WholeNumber(_origin);

            return WholeNumber(MixedParts()[MixedPartsWholeIndex]);
        }

        private double Fraction()
        {
            if (NotMixedNumber() && NoFraction()) return 0;
            if (NotMixedNumber() && HasFraction()) return FractionNumber(_origin);

            return FractionNumber(MixedParts()[MixedPartsFractionIndex]);
        }

        private double WholeNumber(string wholeValue) => double.Parse(wholeValue);

        private double FractionNumber(string fractionString)
        {
            string[] fractionParts = fractionString.Split(FractionSeparator);
            return double.Parse(fractionParts[0]) / double.Parse(fractionParts[1]);
        }

        private string[] MixedParts() => _origin.Split(MixedSeparator);
        private bool NotMixedNumber() => !_origin.Contains(MixedSeparator);
        private bool NoFraction() => !_origin.Contains(FractionSeparator);
        private bool HasFraction() => !NoFraction();
    }
}