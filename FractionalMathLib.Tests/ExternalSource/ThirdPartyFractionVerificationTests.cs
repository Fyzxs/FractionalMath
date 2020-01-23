using FluentAssertions;
using FractionalMathLib.ExternalSource;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionalMathLib.Tests
{
    [TestClass]
    public class ThirdPartyFractionVerificationTests
    {
        [TestMethod]
        public void VerifyRepeatingGetsRightResult()
        {
            double n = 1;
            double d = 3;
            double dbl = n/d;
            Fractions.Fraction actual = Fractions.RealToFraction(dbl);

            actual.N.Should().Be((int)n);
            actual.D.Should().Be((int)d);

        }
        [TestMethod]
        public void VerifyIrrationalGetsRightResult()
        {
            Fractions.Fraction actual = Fractions.RealToFraction(3.14159);

            actual.N.Should().Be((int)238_010);
            actual.D.Should().Be((int)75_761);
        }
    }
}
