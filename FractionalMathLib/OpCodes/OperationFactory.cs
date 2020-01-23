using FractionalMathLib.Exceptions;
using FractionalMathLib.Results.Doubles;

namespace FractionalMathLib.OpCodes
{
    /// <summary>
    /// Strategizes correct class for requested operation.
    /// </summary>
    internal sealed class OperationFactory
    {
        private readonly string _origin;

        public OperationFactory(string origin) => _origin = origin;

        /// <summary>
        /// Makes the operation a strategy pattern.
        /// </summary>
        /// <param name="lhs">left hand side operand</param>
        /// <param name="rhs">right hand side operand</param>
        /// <returns>An object that can be used to get the result of the operation</returns>
        /// <exception cref="UnknownOperationException">It's possible to get an unknown operation in. So let's throw.</exception>
        public Result Operation(Result lhs, Result rhs)
        {
            if (_origin == "+") return new AdditionOperationResult(lhs, rhs);
            if (_origin == "-") return new SubtractionOperationResult(lhs, rhs);
            if (_origin == "*") return new MultiplicationOperationResult(lhs, rhs);
            if (_origin == "/") return new DivisionOperationResult(lhs, rhs);

            //TODO: Future improvement - Validate operations greedily instead of lazily.
            throw new UnknownOperationException(_origin);
        }
    }
}