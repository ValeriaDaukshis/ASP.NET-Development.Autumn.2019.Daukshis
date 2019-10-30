using NUnit.Framework;

namespace StringExtensions.Tests
{
    public class StringExtensionsTests
    {
        [TestCase("12345", 2, ExpectedResult = "15432")]
        [TestCase("12345", 256, ExpectedResult = "12345")]
        [TestCase("123456789", 6_000_000, ExpectedResult = "123456789")]
        [TestCase("123456789A", 7, ExpectedResult = "135792468A")]
        [TestCase("Привет Эпам!", 2, ExpectedResult = "Пепртаи мвЭ!")]
        public string StringExtensions_TestString(string s, int n)
            => StringExtensionsTask.StringExtensions.GenerateString(s, n);
    }
}