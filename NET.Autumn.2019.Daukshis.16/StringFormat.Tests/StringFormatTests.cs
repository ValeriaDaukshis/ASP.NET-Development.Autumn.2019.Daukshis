using System;
using System.Globalization;
using DoubleFormatTask;
using NUnit.Framework;
using StringFormatTask;

namespace StringFormatTests
{
    public class Tests
    {
        private Book book = new Book("C# in Depth", "Jon Skeet", 2019, "Manning", 4, 900, 40);
        private IFormatProvider _formatProviders = new BookFormatProviders();
        private IFormatProvider _formatProvider = new BookFormatProvider();

        [Test]
        public void StringFormat_Author()
        {
            string actual = string.Format(_formatProviders, "Book record: {0:A}", book);
            string expected = "Book record: Jon Skeet";
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void StringFormat_Name()
        {
            string actual = string.Format(_formatProviders, "Book record: {0:N}", book);
            string expected = "Book record: C# in Depth";
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void StringFormat_NameAuthorYear()
        {
            string actual = string.Format(_formatProviders, "Book record: {0:NAY}", book);
            string expected = "Book record: C# in Depth, Jon Skeet, 2019";
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void StringFormat_NameAuthorYearPrice()
        {
            string actual = string.Format(_formatProvider, "Book record: {0:NAYP}", book);
            string expected = "Book record: C# in Depth, Jon Skeet, 2019, 40";
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string BookExtensions_EditionFormat(double value)
         => string.Format(new DoubleFormatProvider(), "{0:NUM}", value);
    }
}