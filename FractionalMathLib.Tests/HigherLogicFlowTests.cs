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
        public void ConsumeMixedNumbers()
        {
            string actual = DoEverything("4_1/3 + 1/3");
            actual.Should().Be("4_2/3");
        }
        [TestMethod]
        public void ConsumeBothMixedNumbers()
        {
            string actual = DoEverything("4_1/3 - 1_2/3");
            actual.Should().Be("2_2/3");
        }

        [TestMethod]
        public void ZeroShouldWork()
        {
            string actual = DoEverything("2 - 2");
            actual.Should().Be("0");
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
            Action action = () => DoEverything("1/4 # 9/3").AsSystemType();

            action.Should().ThrowExactly<UnknownOperationException>().WithMessage("Unknown Operation Requested [opCode=#]");
        }
        [TestMethod]
        public void NoOperationThrowsException()
        {
            Action action = () => DoEverything("1/4 9/3 9/3 9/3").AsSystemType();

            action.Should().ThrowExactly<InvalidArgumentsException>().WithMessage("Invalid request. Not enough parts. [Expected=3] [Found=4]");
        }
        [TestMethod]
        public void SingleOperandThrowsException()
        {
            Action action = () => DoEverything("1/4").AsSystemType();

            action.Should().ThrowExactly<InvalidArgumentsException>().WithMessage("Invalid request. Not enough parts. [Expected=3] [Found=1]");
        }



        private ToSystemType<string> DoEverything(string input)
        {
            string[] arguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if(arguments.Length != 3) throw new InvalidArgumentsException(arguments.Length);

            OperationResult result = new OperationResult(arguments);

            MixedNumberResult almostOutput = new MixedNumberResult(result);

            return almostOutput;
        }
    }
}
