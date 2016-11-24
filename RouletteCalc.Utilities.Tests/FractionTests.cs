using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouletteCalc.Utilities.Math;

namespace RouletteCalc.Utilities.Tests
{
    [TestClass]
    public class FractionTests
    {
        [TestMethod]
        public void Invert_ReturnsCorrectResult()
        {
            int n1 = 646;
            int d1 = 352331;
            Fraction f1 = new Fraction(n1, d1);
            var expected = new Fraction(d1, n1);

            var result = f1.Invert();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OperatorMultiplication_ReturnsCorrectResult()
        {
            int n1 = 34;
            int d1 = 4124;
            Fraction f1 = new Fraction(n1, d1);
            int n2 = 34;
            int d2 = 3141;
            Fraction f2 = new Fraction(n2, d2);
            var expected = new Fraction(n1 * n2, d1 * d2);

            var result = f1 * f2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OperatorAddition_ReturnsCorrectResult()
        {
            int n1 = 646;
            int d1 = 352331;
            Fraction f1 = new Fraction(n1, d1);
            int n2 = 23131;
            int d2 = 1323451;
            Fraction f2 = new Fraction(n2, d2);
            var expected = new Fraction(n1 * d2 + n2 * d1, d1 * d2);

            var result = f1 + f2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OperatorSubtraction_ReturnsCorrectResult()
        {
            int n1 = 12412;
            int d1 = 341;
            Fraction f1 = new Fraction(n1, d1);
            int n2 = 67785;
            int d2 = 313;
            Fraction f2 = new Fraction(n2, d2);
            var expected = new Fraction(n1 * d2 - n2 * d1, d1 * d2);

            var result = f1 - f2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OperatorDivision_ReturnsCorrectResult()
        {
            int n1 = 123;
            int d1 = 23;
            Fraction f1 = new Fraction(n1, d1);
            int n2 = 33412;
            int d2 = 123;
            Fraction f2 = new Fraction(n2, d2);
            var expected = f1 * f2.Invert();

            var result = f1 / f2;

            Assert.AreEqual(expected, result);
        }

    }
}
