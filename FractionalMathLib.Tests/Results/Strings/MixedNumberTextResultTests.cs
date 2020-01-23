using FluentAssertions;
using FractionalMathLib.Results.Strings;
using FractionalMathLib.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Results.Strings
{
    [TestClass]
    public class MixedNumberTextResultTests
    {
        [TestMethod]
        public void ReturnsBothParts()
        {
            //Arrange
            MixedNumberTextResult subject = new MixedNumberTextResult(new FakeResult(1.1));

            //Act
            string actual = subject.AsSystemType();

            //Assert
            actual.Should().Be("1_1/10");
        }

        [TestMethod]
        public void ReturnsIntPart()
        {
            //Arrange
            MixedNumberTextResult subject = new MixedNumberTextResult(new FakeResult(5));

            //Act
            string actual = subject.AsSystemType();

            //Assert
            actual.Should().Be("5");
        }
        [TestMethod]
        public void ReturnsFractionPart()
        {
            //Arrange
            MixedNumberTextResult subject = new MixedNumberTextResult(new FakeResult(.5));

            //Act
            string actual = subject.AsSystemType();

            //Assert
            actual.Should().Be("1/2");
        }
        [TestMethod]
        public void ReturnsZero()
        {
            //Arrange
            MixedNumberTextResult subject = new MixedNumberTextResult(new FakeResult(0));

            //Act
            string actual = subject.AsSystemType();

            //Assert
            actual.Should().Be("0");
        }
    }
}