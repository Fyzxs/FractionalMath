using System;
using FluentAssertions;
using FractionalMathLib.Exceptions;
using FractionalMathLib.Lib;
using FractionalMathLib.Lib.Texts;
using FractionalMathLib.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests
{
    [TestClass]
    public class HigherLogicFlowTests
    {
        [TestMethod]
        public void OneThirdPlusOneFourthShouldBeSevenTwelfth()
        {
            string actual = DoEverything("1/3 + 1/4");
            actual.Should().Be("7/12");
        }

        [TestMethod]
        public void OneThirdPlusOneFourthShouldBeSevenTwelfthEvenIfReversed()
        {
            string actual = DoEverything("1/4 + 1/3");
            actual.Should().Be("7/12");
        }

        [TestMethod]
        public void NineThirdPlusOneFourthShouldBeTwentyFiveTwelfthExceptAsThreeAndOneFourth()
        {
            string actual = DoEverything("9/3 + 1/4");
            actual.Should().Be("3_1/4");
        }

        [TestMethod]
        public void NegativeNineThirdPlusNegativeOneFourthShouldBeTwentyFiveTwelfthExceptAsThreeAndOneFourth()
        {
            string actual = DoEverything("-9/3 + -1/4");
            actual.Should().Be("-3_1/4");
        }

        [TestMethod]
        public void OneFourthPlusNegativeNineThirdShouldBeNegativeTwoAndThreeFourths()
        {
            string actual = DoEverything("1/4 + -9/3");
            actual.Should().Be("-2_3/4");
        }

        [TestMethod]
        public void OneFourthSubtractNineThirdShouldBeNegativeTwoAndThreeFourths()
        {
            string actual = DoEverything("1/4 - 9/3");
            actual.Should().Be("-2_3/4");
        }

        [TestMethod]
        public void TwoPlusFourShouldBeSix()
        {
            string actual = DoEverything("2 + 4");
            actual.Should().Be("6");
        }
        [TestMethod]
        public void TwoMinusFourShouldBeMinus2()
        {
            string actual = DoEverything("2 - 4");
            actual.Should().Be("-2");
        }

        [TestMethod]
        public void HandlesManySpacesOneFourthSubtractNineThirdShouldBeNegativeTwoAndThreeFourths()
        {
            string actual = DoEverything("          1/4      -      9/3    ");
            actual.Should().Be("-2_3/4");
        }

        [TestMethod]
        public void UnknownOperationThrowsException()
        {
            Action action = () => DoEverything("1/4 # 9/3");

            action.Should().ThrowExactly<UnknownOperationException>().WithMessage("Unknown Operation Requested [opCode=#]");
        }



        private ToSystemType<string> DoEverything(string input)
        {
            string[] arguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Result firstOp = new NumberResult(arguments[0]);
            Result secondOp = new NumberResult(arguments[2]);
            OpCode opCode = new OpCode(arguments[1]);
            Result opResult = opCode.Operation(firstOp, secondOp);

            MixedNumberResult almostOutput = new MixedNumberResult(opResult);

            return almostOutput;
        }
    }

    public sealed class OpCode
    {
        private readonly string _origin;

        public OpCode(string origin) => _origin = origin;

        public Result Operation(Result lhs, Result rhs)
        {
            if (_origin == "+") return new AdditionOperationResult(lhs, rhs);
            if (_origin == "-") return new AdditionOperationResult(lhs, rhs.Negate());

            throw new UnknownOperationException(_origin);
        }
    }
}
