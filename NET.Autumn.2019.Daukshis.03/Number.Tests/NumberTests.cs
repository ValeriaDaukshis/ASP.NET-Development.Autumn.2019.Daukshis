
using NUnit.Framework;

namespace Number.Tests
{
    [TestFixture]
    public class NumberTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(124121133, ExpectedResult = 124121313)]
        [TestCase(int.MaxValue, ExpectedResult = -1)]
        [TestCase(2000, ExpectedResult = -1)]
        [TestCase(111111111, ExpectedResult = -1)]
        public int FindNextBiggerNumber_NumberExpected(int number)
            => NextBiggerThanClass.Number.FindNextBiggerNumber(number);
    }
}
