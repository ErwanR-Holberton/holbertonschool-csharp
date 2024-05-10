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
    }
}
