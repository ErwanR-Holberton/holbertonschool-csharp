using NUnit.Framework;

namespace Text.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string s1 = "rrr";
            int result = Str.CamelCase(s1);
            Assert.AreEqual(1, result);
        }
        [Test]
        public void Test2()
        {
            string s1 = "rRr";
            int result = Str.CamelCase(s1);
            Assert.AreEqual(2, result);
        }
        [Test]
        public void Test3()
        {
            string s1 = "";
            int result = Str.CamelCase(s1);
            Assert.AreEqual(0, result);
        }
        [Test]
        public void Test4()
        {
            string s1 = "thisIsATest";
            int result = Str.CamelCase(s1);
            Assert.AreEqual(4, result);
        }
    }
}
