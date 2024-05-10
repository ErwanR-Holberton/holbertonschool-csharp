using NUnit.Framework;

namespace Text.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string s1 = "racecar";
            int result = Str.UniqueChar(s1);
            Assert.AreEqual(3, result);
        }
        [Test]
        public void Test2()
        {
            string s1 = "rrr";
            int result = Str.UniqueChar(s1);
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void Test3()
        {
            string s1 = "";
            int result = Str.UniqueChar(s1);
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void Test4()
        {
            string s1 = "abc";
            int result = Str.UniqueChar(s1);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void Test5()
        {
            string s1 = "t";
            int result = Str.UniqueChar(s1);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void Test6()
        {
            string s1 = "aazzeer";
            int result = Str.UniqueChar(s1);
            Assert.AreEqual(6, result);
        }
    }
}
