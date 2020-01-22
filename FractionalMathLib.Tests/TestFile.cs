using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests
{
    [TestClass]
    public class TestFile
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

        private string DoEverything(string input)
        {
            string[] arguments = input.Split(" ");

            double firstOp = GetFractionAsDouble(arguments[0]);
            double secondOp = GetFractionAsDouble(arguments[2]);

            double result = firstOp + secondOp;
            Fractions.Fraction realToFraction = Fractions.RealToFraction(result);

            return realToFraction.ToString();
        }

        private static double GetFractionAsDouble(string strOperand)
        {
            string[] firstFraction = strOperand.Split("/");

            return double.Parse(firstFraction[0]) / double.Parse(firstFraction[1]);
        }
    }
}
