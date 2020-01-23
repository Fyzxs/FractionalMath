namespace FractionalMathLib.Results.Doubles
{
    internal sealed class DivisionOperationResult : Result
    {
        private readonly Result _lhs;
        private readonly Result _rhs;

        public DivisionOperationResult(Result lhs, Result rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public override double AsSystemType() => _lhs.AsSystemType() / _rhs.AsSystemType();
    }
}