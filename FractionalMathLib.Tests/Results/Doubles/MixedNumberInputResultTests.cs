using FluentAssertions;
using FractionalMathLib.Results.Doubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Results.Doubles
{
    [TestClass]
    public class MixedNumberInputResultTests
    {
        [TestMethod]
        public void ParsesCorrectly()
        {
            //Arrange
            MixedNumberInputResult subject = new MixedNumberInputResult("1_1/2");

            //Act
            double actual = subject.AsSystemType();

            //Assert
            actual.Should().Be(3/2d);
        }
    }
}