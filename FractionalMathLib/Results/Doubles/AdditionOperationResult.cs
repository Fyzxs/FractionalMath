namespace FractionalMathLib.Results.Doubles 
{
    /// <summary>
    /// Encapsulates the addition of multiple results
    /// </summary>
    internal sealed class AdditionOperationResult : Result
    {
        private readonly Result _lhs;
        private readonly Result _rhs;

        public AdditionOperationResult(Result lhs, Result rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public override double AsSystemType() => _lhs.AsSystemType() + _rhs.AsSystemType();
    }
}