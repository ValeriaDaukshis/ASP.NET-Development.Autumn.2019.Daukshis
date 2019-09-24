
using NUnit.Framework;

namespace Number.Tests
{
    [TestFixture]
    public class NumberTests
    {
        [TestCase(12, ExpectedResult = null)]
        [TestCase(513, ExpectedResult = 351)]
        [TestCase(2017, ExpectedResult = 1720)]
        [TestCase(414, ExpectedResult = 144)]
        [TestCase(144, ExpectedResult = null)]
        [TestCase(1234321, ExpectedResult = 1234312)]
        [TestCase(int.MaxValue, ExpectedResult = null)]
        [TestCase(int.MaxValue-1, ExpectedResult = null)]
        [TestCase(2000, ExpectedResult = 2)]
        [TestCase(111111111, ExpectedResult = null)]
        public int? FindNextBiggerNumber_NumberExpected(int number)
            => NextBiggerThanClass.NumbersExtension.FindNextBiggerNumber(number);
    }
}
