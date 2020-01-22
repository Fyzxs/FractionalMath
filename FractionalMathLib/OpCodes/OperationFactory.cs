using FractionalMathLib.Exceptions;
using FractionalMathLib.Results;

namespace FractionalMathLib.OpCodes
{
    public sealed class OperationFactory
    {
        private readonly string _origin;

        public OperationFactory(string origin) => _origin = origin;

        public Result Operation(Result lhs, Result rhs)
        {
            if (_origin == "+") return new AdditionOperationResult(lhs, rhs);
            if (_origin == "-") return new AdditionOperationResult(lhs, rhs.Negate());
            if (_origin == "*") return new MultiplicationOperationResult(lhs, rhs);

            throw new UnknownOperationException(_origin);
        }
    }
}