using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests
{
    [TestClass]
    public class ToSystemTypeTests
    {
        [TestMethod]
        public void OperatesCorrectly()
        {
            //Arrange
            ToSystemType<bool> subject = new FakeToSystemType<bool>(true);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        
        private sealed class FakeToSystemType<T>:ToSystemType<T>
        {
            private readonly T _origin;

            public FakeToSystemType(T origin) => _origin = origin;

            public override T AsSystemType() => _origin;
        }
    }
}