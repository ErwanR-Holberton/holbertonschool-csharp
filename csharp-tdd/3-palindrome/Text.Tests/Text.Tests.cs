using NUnit.Framework;

namespace Text.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string s1 = "Racecar";
            bool result = Str.IsPalindrome(s1);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void Test2()
        {
            string s1 = "level";
            bool result = Str.IsPalindrome(s1);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void Test3()
        {
            string s1 = "A man, a plan, a canal: Panama.";
            bool result = Str.IsPalindrome(s1);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void Test4()
        {
            string s1 = "abc";
            bool result = Str.IsPalindrome(s1);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void Test5()
        {
            string s1 = "a";
            bool result = Str.IsPalindrome(s1);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void Test6()
        {
            string s1 = "";
            bool result = Str.IsPalindrome(s1);
            Assert.AreEqual(true, result);
        }
    }
}
