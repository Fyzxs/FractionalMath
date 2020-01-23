using System.Collections.Generic;
using FractionalMathLib.OpCodes;

namespace FractionalMathLib.Results.Doubles
{
    /// <summary>
    /// Encapsulates the knowledge of how the input of operands and operations relate.
    /// </summary>
    internal sealed class OperationResult : Result
    {
        //Note: Swapping the index values of LHS and Operand, this would do polish notation.
        //Note: Swapping the index values of RHS and Operand, this would do reverse polish notion.
        //Note: I could "EXTRACT WHAT VARIES" and make all three super simple to have as options.
        private const int LeftHandSideOperandIndex = 0;
        private const int RightHandSideOperandIndex = 2;
        private const int OperandIndex = 1;

        private readonly Result _lhs;
        private readonly Result _rhs;
        private readonly OperationFactory _operationFactory;

        public OperationResult(IReadOnlyList<string> arguments) 
            : this(new MixedNumberInputResult(arguments[LeftHandSideOperandIndex]), new MixedNumberInputResult(arguments[RightHandSideOperandIndex]), new OperationFactory(arguments[OperandIndex])){ }

        private OperationResult(Result lhs, Result rhs, OperationFactory operationFactory)
        {
            _lhs = lhs;
            _rhs = rhs;
            _operationFactory = operationFactory;
        }

        public override double AsSystemType() => _operationFactory.Operation(_lhs, _rhs);
    }
}