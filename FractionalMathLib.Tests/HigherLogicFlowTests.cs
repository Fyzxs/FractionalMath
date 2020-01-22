using FluentAssertions;
using FractionalMathLib.Lib;
using FractionalMathLib.Lib.Text;
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



        private ToSystemType<string> DoEverything(string input)
        {
            string[] arguments = input.Split(" ");

            Result firstOp = new NumberResult(arguments[0]);
            Result secondOp = new NumberResult(arguments[2]);
            AdditionOperationResult result = new AdditionOperationResult(firstOp, secondOp);
            ResultToString almostOutput = new ResultToString(result);

            return almostOutput;
        }
    }
}
