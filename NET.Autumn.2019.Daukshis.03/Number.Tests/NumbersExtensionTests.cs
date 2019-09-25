using NextBiggerThanClass;
using NUnit.Framework;

namespace Number.Tests
{
    [TestFixture]
    public class NumbersExtensionTests
    {
        [TestCase(12, ExpectedResult = null)]
        [TestCase(513, ExpectedResult = 351)]
        [TestCase(2017, ExpectedResult = 1720)]
        [TestCase(414, ExpectedResult = 144)]
        [TestCase(144, ExpectedResult = null)]
        [TestCase(1234321, ExpectedResult = 1234312)]
        [TestCase(int.MaxValue, ExpectedResult = 2147483476)] 
        [TestCase(2000, ExpectedResult = 200)]
        [TestCase(111111111, ExpectedResult = null)]
        public int? FindNextBiggerNumber_NumberExpected(int number)
            => NumbersExtension.FindPreviousLessThan(number, new FindPreviousLess(), new ReverseSorting());
    }
}
