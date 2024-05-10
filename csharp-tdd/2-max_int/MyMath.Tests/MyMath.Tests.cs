using NUnit.Framework;
using System.Collections.Generic;

namespace MyMath.Tests
{
    public class Tests
    {
        [Test]
        public void max_normal()
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4, 5};
            int result = Operations.Max(list1);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void max_empty()
        {
            List<int> list1 = new List<int> {};
            int result = Operations.Max(list1);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void max_empty2()
        {
            List<int> list1 = new List<int>();
            int result = Operations.Max(list1);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void max_negative()
        {
            List<int> list1 = new List<int> { -1, -2, -3, -4, -5};
            int result = Operations.Max(list1);
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void max_one()
        {
            List<int> list1 = new List<int> {13};
            int result = Operations.Max(list1);
            Assert.AreEqual(13, result);
        }
        [Test]
        public void max_456()
        {
            List<int> list1 = new List<int> { 15, 52, 22, 4, 5};
            int result = Operations.Max(list1);
            Assert.AreEqual(52, result);
        }
    }
}
