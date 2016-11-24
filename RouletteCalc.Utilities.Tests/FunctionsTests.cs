using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouletteCalc.Utilities.Math;

namespace RouletteCalc.Utilities.Tests
{
    [TestClass]
    public class FunctionsTests
    {
        [TestMethod]
        public void GCD_aIsZero_ReturnsB()
        {
            int a = 0;
            int b = 30;

            int result = Functions.GCD(a, b);

            Assert.AreEqual(b, result);
        }

        [TestMethod]
        public void GCD_bIsZero_ReturnsA()
        {
            int a = 31311;
            int b = 0;

            var result = Functions.GCD(a, b);

            Assert.AreEqual(a, result);
        }

        [TestMethod]
        public void GCD_aIsOne_ResturnOne()
        {
            int a = 1;
            int b = 123123;

            var result = Functions.GCD(a, b);

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void GCD_bIsOne_ResturnOne()
        {
            int a = 52351234;
            int b = 1;

            var result = Functions.GCD(a, b);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GCD_aIs256_bIs48_Returns16()
        {
            int a = 256;
            int b = 48;
            int expected = 16;

            var result = Functions.GCD(a, b);

            Assert.AreEqual(expected, result);
        }
    }
}
