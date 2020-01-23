using FluentAssertions;
using FractionalMathLib.Results.Strings;
using FractionalMathLib.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Results.Strings
{
    [TestClass]
    public class IntegerMixedNumberTextResultTests
    {
        [TestMethod]
        public void ReturnsEmptyStringForNoInteger()
        {
            //Arrange
            IntegerMixedNumberTextResult subject = new IntegerMixedNumberTextResult(new FakeResult(.1));

            //Act
            string actual = subject.AsSystemType();

            //Assert
            actual.Should().BeEmpty();
        }

        [TestMethod]
        public void ReturnsIntPart()
        {
            //Arrange
            IntegerMixedNumberTextResult subject = new IntegerMixedNumberTextResult(new FakeResult(5.5));

            //Act
            string actual = subject.AsSystemType();

            //Assert
            actual.Should().Be("5");
        }
    }
}