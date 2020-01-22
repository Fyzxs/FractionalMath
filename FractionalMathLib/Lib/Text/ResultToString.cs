using FractionalMathLib.Results;
using FractionalMathLib.ToRefactor;

namespace FractionalMathLib.Lib.Text {
    public sealed class ResultToString: ToSystemType<string>
    {
        private readonly Result _origin;

        public ResultToString(Result origin) => _origin = origin;

        public override string AsSystemType()
        {
            //TODO: Refactor this imperative mess
            double sourceValue = _origin.AsSystemType();
            int truncated = (int)sourceValue;
            double toFraction = sourceValue - truncated;
            string integerString = 0 < truncated ? truncated + "_" : "";
            string fractionString = Fractions.RealToFraction(toFraction).ToString();

            return $"{integerString}{fractionString}";
        }
    }
}