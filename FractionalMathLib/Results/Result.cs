using FractionalMathLib.Lib;

namespace FractionalMathLib.Results {
    public abstract class Result : ToSystemType<double>
    {
        public Result Negate()
        {
            return new NegateResult(this);
        }
    }
}