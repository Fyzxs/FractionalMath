using FractionalMathLib.Results;
using FractionalMathLib.ToRefactor;

namespace FractionalMathLib.Lib.Text {
    public sealed class ResultToString: ToSystemType<string>
    {
        private readonly Result _origin;

        public ResultToString(Result origin) => _origin = origin;

        public override string AsSystemType() => Fractions.RealToFraction(_origin.AsSystemType()).ToString();
    }
}