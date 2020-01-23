namespace FractionalMathLib.Results.Doubles
{
    /// <summary>
    /// Encapsulates the subtraction of multiple results
    /// </summary>
    internal sealed class SubtractionOperationResult : Result
    {
        private readonly Result _lhs;
        private readonly Result _rhs;

        public SubtractionOperationResult(Result lhs, Result rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public override double AsSystemType() => _lhs.AsSystemType() - _rhs.AsSystemType();
    }
}