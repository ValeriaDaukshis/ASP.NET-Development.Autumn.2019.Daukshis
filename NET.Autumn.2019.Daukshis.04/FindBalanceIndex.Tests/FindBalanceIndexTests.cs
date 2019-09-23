using System;
using FindBalanceIndexTask;
using NUnit.Framework;

namespace FindBalanceIndex.Tests
{
    [TestFixture]
    public class FindBalanceIndexTests
    {
        [TestCase(new int[] { 0, 25, 34, 10, 0, 15 }, ExpectedResult = 2)]
        [TestCase(new int[] { 0, 26, 34, 10, 0, 15 }, ExpectedResult = null)]
        [TestCase(new int[] { 0, 20, 21, 50, 10, 101, 100, 1 }, ExpectedResult = 5)]
        [TestCase(new int[] { 20, 21, 50, 10, 5, 101 }, ExpectedResult = 4)]
        [TestCase(new int[] { Int32.MaxValue, 0, Int32.MaxValue, 10}, ExpectedResult = null)]
        public object FindBalanceIndex_Array_IndexExpected(int[] array)
            => ArrayExtension.FindBalanceIndex(array);

        [Test]
        public void FindBalanceIndex_NullArray_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => ArrayExtension.FindBalanceIndex(null));
        }
    }
}
