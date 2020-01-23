using FluentAssertions;
using FractionalMathLib.Results.Doubles;
using FractionalMathLib.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Results.Doubles
{
    [TestClass]
    public class DivisionOperationResultTests
    {
        [TestMethod]
        public void OperatesCorrectly()
        {
            //Arrange
            AdditionOperationResult subject = new AdditionOperationResult(new FakeResult(1), new FakeResult(2));

            //Act
            double actual = subject.AsSystemType();

            //Assert
            actual.Should().Be(3);
        }
    }
}
