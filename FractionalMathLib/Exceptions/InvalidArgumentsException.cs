using System;

namespace FractionalMathLib.Exceptions
{
    public sealed class InvalidArgumentsException : Exception
    {
        private readonly int _argCount;

        public InvalidArgumentsException(int argCount) => _argCount = argCount;

        public override string Message => $"Invalid request. Not enough parts. [Expected=3] [Found={_argCount}]";
    }
}