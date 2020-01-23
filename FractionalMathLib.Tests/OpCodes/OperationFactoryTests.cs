using System;
using FluentAssertions;
using FractionalMathLib.Exceptions;
using FractionalMathLib.OpCodes;
using FractionalMathLib.Results.Doubles;
using FractionalMathLib.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests.Exceptions
{
    [TestClass]
    public class OperationFactoryTests
    {
        [TestMethod]
        public void ProvidesAdditionOperation()
        {
            //Arrange
            OperationFactory subject = new OperationFactory("+");

            //Act
            Result actual = subject.Operation(new FakeResult(),new FakeResult());

            //Assert
            actual.Should().BeOfType<AdditionOperationResult>();
        }
        [TestMethod]
        public void ProvidesSubtractionOperation()
        {
            //Arrange
            OperationFactory subject = new OperationFactory("-");

            //Act
            Result actual = subject.Operation(new FakeResult(),new FakeResult());

            //Assert
            actual.Should().BeOfType<SubtractionOperationResult>();
        }

        [TestMethod]
        public void ProvidesMultiplicationOperation()
        {
            //Arrange
            OperationFactory subject = new OperationFactory("*");

            //Act
            Result actual = subject.Operation(new FakeResult(),new FakeResult());

            //Assert
            actual.Should().BeOfType<MultiplicationOperationResult>();
        }

        [TestMethod]
        public void ProvidesDivisionOperation()
        {
            //Arrange
            OperationFactory subject = new OperationFactory("/");

            //Act
            Result actual = subject.Operation(new FakeResult(),new FakeResult());

            //Assert
            actual.Should().BeOfType<DivisionOperationResult>();
        }

        [TestMethod]
        public void ShouldThrowOnUnknownOp()
        {
            //Arrange
            OperationFactory subject = new OperationFactory("#");

            //Act
            Action action = () => subject.Operation(new FakeResult(),new FakeResult());

            //Assert
            action.Should().ThrowExactly<UnknownOperationException>();
        }
    }
}
