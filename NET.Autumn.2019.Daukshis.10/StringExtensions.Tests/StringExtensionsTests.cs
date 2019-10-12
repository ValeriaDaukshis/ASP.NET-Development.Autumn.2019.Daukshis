using NUnit.Framework;

namespace StringExtensions.Tests
{
    public class StringExtensionsTests
    {
        [TestCase("abc def Ghi j", ExpectedResult = new string[] {"abc", "def", "Ghi", "j"})]
        [TestCase("as As as fd g", ExpectedResult = new string[] {"as", "fd", "g"})]
        [TestCase("as-As:as fd g,g.lk", ExpectedResult = new string[] {"as", "fd", "g", "lk"})]
        public string[] Test1(string text)
            => Task3.StringExtensions.GetWords(text);
    }
}