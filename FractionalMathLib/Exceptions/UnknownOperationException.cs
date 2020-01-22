using System;

namespace FractionalMathLib.Exceptions
{
    public sealed class UnknownOperationException : Exception
    {
        private readonly string _opCode;

        public UnknownOperationException(string opCode) => _opCode = opCode;
        public override string Message => $"Unknown Operation Requested [opCode={_opCode}]";
    }
}