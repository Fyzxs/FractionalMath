using FluentAssertions;
using FractionalMathLib.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Exceptions
{
    [TestClass]
    public class UnknownOperationExceptionTests
    {
        [TestMethod]
        public void MessageIsExpected()
        {
            //Arrange
            string expectedOp = "WRONG_OP";
            UnknownOperationException subject = new UnknownOperationException(expectedOp);

            //Act
            string actual = subject.Message;

            //Assert
            actual.Should().Be($"Unknown Operation Requested [opCode={expectedOp}]");
        }
    }
}
