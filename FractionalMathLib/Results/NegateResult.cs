namespace FractionalMathLib.Results
{
    public sealed class NegateResult : Result
    {
        private readonly Result _result;

        public NegateResult(Result result) => _result = result;

        public override double AsSystemType() => -_result.AsSystemType();
    }
}