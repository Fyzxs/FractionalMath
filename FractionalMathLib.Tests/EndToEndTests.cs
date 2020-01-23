using System;
using FluentAssertions;
using FractionalMath;
using FractionalMathLib.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests
{
    [TestClass]
    public class EndToEndTests
    {
        [TestMethod]
        public void OneThirdPlusOneFourthShouldBeSevenTwelfth()
        {
            string actual = FractionalMathProgram.ProcessInput("1/3 + 1/4");
            actual.Should().Be("7/12");
        }

        [TestMethod]
        public void OneThirdPlusOneFourthShouldBeSevenTwelfthEvenIfReversed()
        {
            string actual = FractionalMathProgram.ProcessInput("1/4 + 1/3");
            actual.Should().Be("7/12");
        }

        [TestMethod]
        public void NineThirdPlusOneFourthShouldBeTwentyFiveTwelfthExceptAsThreeAndOneFourth()
        {
            string actual = FractionalMathProgram.ProcessInput("9/3 + 1/4");
            actual.Should().Be("3_1/4");
        }

        [TestMethod]
        public void NegativeNineThirdPlusNegativeOneFourthShouldBeTwentyFiveTwelfthExceptAsThreeAndOneFourth()
        {
            string actual = FractionalMathProgram.ProcessInput("-9/3 + -1/4");
            actual.Should().Be("-3_1/4");
        }

        [TestMethod]
        public void OneFourthPlusNegativeNineThirdShouldBeNegativeTwoAndThreeFourths()
        {
            string actual = FractionalMathProgram.ProcessInput("1/4 + -9/3");
            actual.Should().Be("-2_3/4");
        }

        [TestMethod]
        public void OneFourthSubtractNineThirdShouldBeNegativeTwoAndThreeFourths()
        {
            string actual = FractionalMathProgram.ProcessInput("1/4 - 9/3");
            actual.Should().Be("-2_3/4");
        }

        [TestMethod]
        public void TwoPlusFourShouldBeSix()
        {
            string actual = FractionalMathProgram.ProcessInput("2 + 4");
            actual.Should().Be("6");
        }
        [TestMethod]
        public void TwoMinusFourShouldBeMinus2()
        {
            string actual = FractionalMathProgram.ProcessInput("2 - 4");
            actual.Should().Be("-2");
        }
        [TestMethod]
        public void ConsumeMixedNumbers()
        {
            string actual = FractionalMathProgram.ProcessInput("4_1/3 + 1/3");
            actual.Should().Be("4_2/3");
        }
        [TestMethod]
        public void ConsumeBothMixedNumbers()
        {
            string actual = FractionalMathProgram.ProcessInput("4_1/3 - 1_2/3");
            actual.Should().Be("2_2/3");
        }

        [TestMethod]
        public void ZeroShouldWork()
        {
            string actual = FractionalMathProgram.ProcessInput("2 - 2");
            actual.Should().Be("0");
        }

        [TestMethod]
        public void TwoDividedByFourShouldBeHalf()
        {
            string actual = FractionalMathProgram.ProcessInput("2 / 4");
            actual.Should().Be("1/2");
        }

        [TestMethod]
        public void HandlesManySpacesOneFourthSubtractNineThirdShouldBeNegativeTwoAndThreeFourths()
        {
            string actual = FractionalMathProgram.ProcessInput("          1/4      -      9/3    ");
            actual.Should().Be("-2_3/4");
        }

        [TestMethod]
        public void UnknownOperationThrowsException()
        {
            Action action = () => FractionalMathProgram.ProcessInput("1/4 # 9/3");

            action.Should().ThrowExactly<UnknownOperationException>().WithMessage("Unknown Operation Requested [opCode=#]");
        }
        [TestMethod]
        public void NoOperationThrowsException()
        {
            Action action = () => FractionalMathProgram.ProcessInput("1/4 9/3 9/3 9/3");

            action.Should().ThrowExactly<InvalidArgumentsException>().WithMessage("Invalid request. Not enough parts. [Expected=3] [Found=4]");
        }
        [TestMethod]
        public void SingleOperandThrowsException()
        {
            Action action = () => FractionalMathProgram.ProcessInput("1/4");

            action.Should().ThrowExactly<InvalidArgumentsException>().WithMessage("Invalid request. Not enough parts. [Expected=3] [Found=1]");
        }
    }
}
