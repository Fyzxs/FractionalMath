namespace FractionalMathLib.Results
{
    public sealed class MultiplicationOperationResult : Result
    {
        private readonly Result _lhs;
        private readonly Result _rhs;

        public MultiplicationOperationResult(Result lhs, Result rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public override double AsSystemType() => _lhs.AsSystemType() * _rhs.AsSystemType();
    }
}