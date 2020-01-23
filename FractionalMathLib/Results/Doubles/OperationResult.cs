using System.Collections.Generic;
using FractionalMathLib.OpCodes;

namespace FractionalMathLib.Results.Doubles
{
    public sealed class OperationResult : Result
    {
        private readonly Result _lhs;
        private readonly Result _rhs;
        private readonly OperationFactory _operationFactory;

        public OperationResult(IReadOnlyList<string> arguments) 
            : this(new MixedNumberInputResult(arguments[0]), new MixedNumberInputResult(arguments[2]), new OperationFactory(arguments[1])){ }

        private OperationResult(Result lhs, Result rhs, OperationFactory operationFactory)
        {
            _lhs = lhs;
            _rhs = rhs;
            _operationFactory = operationFactory;
        }

        public override double AsSystemType() => _operationFactory.Operation(_lhs, _rhs);
    }
}