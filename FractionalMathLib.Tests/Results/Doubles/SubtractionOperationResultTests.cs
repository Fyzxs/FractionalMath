using FluentAssertions;
using FractionalMathLib.Results.Doubles;
using FractionalMathLib.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Results.Doubles
{
    [TestClass]
    public class SubtractionOperationResultTests
    {
        [TestMethod]
        public void OperatesCorrectly()
        {
            //Arrange
            SubtractionOperationResult subject = new SubtractionOperationResult(new FakeResult(1), new FakeResult(2));

            //Act
            double actual = subject.AsSystemType();

            //Assert
            actual.Should().Be(-1);
        }
    }
}