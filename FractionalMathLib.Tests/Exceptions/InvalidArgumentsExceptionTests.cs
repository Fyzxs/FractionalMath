using FluentAssertions;
using FractionalMathLib.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Exceptions
{
    [TestClass]
    public class InvalidArgumentsExceptionTests
    {
        [TestMethod]
        public void MessageIsExpected()
        {
            //Arrange
            int expectedCount = 10;
            InvalidArgumentsException subject = new InvalidArgumentsException(expectedCount);

            //Act
            string actual = subject.Message;

            //Assert
            actual.Should().Be($"Invalid request. Not enough parts. [Expected=3] [Found={expectedCount}]");
        }
    }
}
