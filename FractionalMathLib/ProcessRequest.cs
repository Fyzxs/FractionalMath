using System;
using System.Collections.Generic;
using FractionalMathLib.Results.Doubles;
using FractionalMathLib.Results.Strings;

namespace FractionalMathLib
{
    /// <summary>
    /// The narrow interface to the deep functionality of the Fractional Math!
    /// </summary>
    public interface IProcessRequest
    {
        string ProcessInput(string input);
    }


    /// <summary>
    /// The implementation of the narrow interface to the deep functionality of the Fractional Math!
    /// </summary>
    public sealed class ProcessRequest : IProcessRequest
    {
        private static readonly char[] InputSeparator = new []{' '};

        public string ProcessInput(string input)
        {
            string[] arguments = input.Split(InputSeparator, StringSplitOptions.RemoveEmptyEntries);

            return InvalidArgumentCount(arguments)
                ? $"Invalid request. Not enough parts. [Expected=3] [Found={arguments.Length}]"
                : new MixedNumberTextResult(new OperationResult(arguments));
        }

        private static bool InvalidArgumentCount(IReadOnlyCollection<string> arguments) => arguments.Count != 3;
    }
}