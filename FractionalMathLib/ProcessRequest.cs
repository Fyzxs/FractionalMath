﻿using System;
using System.Collections.Generic;
using FractionalMathLib.Results.Doubles;
using FractionalMathLib.Results.Strings;

namespace FractionalMathLib
{
    /* Note: A common feature of the MicroObjects (https://quinngil.com/uobjects/) style of development; there are very few classes exposed to consumers.
        In this project, The contents of this file is the only one that outside consumers can see.
        All of the functionality accessed through a single interface... not a lot of questions on how to use the functionality.
    */

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