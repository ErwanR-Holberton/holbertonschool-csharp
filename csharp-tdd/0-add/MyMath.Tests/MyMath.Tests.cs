using NUnit.Framework;

namespace MyMath.Tests
{
    [TestFixture]
    public class OperationsTests
    {

        [Test]
        public void Add_WhenCalledWithTwoPositiveNumbers_ReturnsCorrectResult()
        {
            int a = 5;
            int b = 3;
            int result = Operations.Add(a, b);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Add_WhenCalledWithNegativeNumbers_ReturnsCorrectResult()
        {
            int a = -5;
            int b = -3;
            int result = Operations.Add(a, b);
            Assert.AreEqual(-8, result);
        }

        [Test]
        public void Add_WhenCalledWithZero_ReturnsCorrectResult()
        {
            int a = 0;
            int b = 0;
            int result = Operations.Add(a, b);
            Assert.AreEqual(0, result);
        }
    }
}
