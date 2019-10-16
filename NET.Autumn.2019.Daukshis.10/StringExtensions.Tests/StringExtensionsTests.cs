using NUnit.Framework;

namespace StringExtensions.Tests
{
    public class StringExtensionsTests
    {
        [TestCase("abc def Ghi j", new char[]{' ', ',','.',';',':'}, ExpectedResult = new string[] {"abc", "def", "Ghi", "j"})]
        [TestCase("as As as fd g", new char[]{' ', ',','.',';',':'}, ExpectedResult = new string[] {"as", "fd", "g"})]
        [TestCase("as-As:as fd g,g.lk", new char[]{' ', ',','.',';',':','-'}, ExpectedResult = new string[] {"as", "fd", "g", "lk"})]
        public string[] Test1(string text, char[] punctuation)
            => Task3.StringExtensions.GetWords(text, punctuation);
    }
}