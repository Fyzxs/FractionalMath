using FluentAssertions;
using FractionalMathLib.Results.Doubles;
using FractionalMathLib.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Results.Doubles
{
    [TestClass]
    public class AdditionOperationResultTests
    {
        [TestMethod]
        public void OperatesCorrectly()
        {
            //Arrange
            DivisionOperationResult subject = new DivisionOperationResult(new FakeResult(1), new FakeResult(2));

            //Act
            double actual = subject.AsSystemType();

            //Assert
            actual.Should().Be(1/2d);
        }
    }
}
