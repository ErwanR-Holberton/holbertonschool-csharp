using NUnit.Framework;

namespace MyMath.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_WhenGivenTwoPositiveIntegers_ReturnsCorrectSum()
        {
            int result = Operations.Add(3, 5);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Add_WhenGivenNegativeAndPositiveIntegers_ReturnsCorrectSum()
        {
            int result = Operations.Add(-3, 5);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Add_WhenGivenTwoNegativeIntegers_ReturnsCorrectSum()
        {
            int result = Operations.Add(-3, -5);
            Assert.AreEqual(-8, result);
        }
    }
}
