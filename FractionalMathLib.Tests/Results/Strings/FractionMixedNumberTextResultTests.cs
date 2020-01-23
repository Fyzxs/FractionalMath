using FluentAssertions;
using FractionalMathLib.Results.Strings;
using FractionalMathLib.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Results.Strings
{
    [TestClass]
    public class FractionMixedNumberTextResultTests
    {
        [TestMethod]
        public void ReturnsEmptyStringForNoFraction()
        {
            //Arrange
            FractionMixedNumberTextResult subject = new FractionMixedNumberTextResult(new FakeResult(1));

            //Act
            string actual = subject.AsSystemType();

            //Assert
            actual.Should().BeEmpty();
        }

        [TestMethod]
        public void ReturnsFractionForm()
        {
            //Arrange
            FractionMixedNumberTextResult subject = new FractionMixedNumberTextResult(new FakeResult(.5));

            //Act
            string actual = subject.AsSystemType();

            //Assert
            actual.Should().Be("1/2");
        }
    }
}