using FluentAssertions;
using FractionalMathLib.Results.Doubles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Results.Doubles
{
    [TestClass]
    public class OperationResultTests
    {
        [TestMethod]
        public void OperatesCorrectly()
        {
            //Arrange
            OperationResult subject = new OperationResult(new []{"1","+","1"});

            //Act
            double actual = subject.AsSystemType();

            //Assert
            actual.Should().Be(2);
        }
    }
}