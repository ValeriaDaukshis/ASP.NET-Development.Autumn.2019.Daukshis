using System;
using NUnit.Framework;
using Filter;

namespace FilterArrayByKey.Tests
{
    [TestFixture]
    public class FilterArrayByKeyTests
    {
        [TestCase(new[] { 121, 1405644, -1036674 }, 2, ExpectedResult = new[] { 121 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult =
            new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        public int[] FilterArrayByKey_ArrayAndValue_FilteredArrayExpected(int[] array, int value)
            => ArrayExtension.FilterArray(array, new FilterByKey(value));

        [Test]
        public void FilterArrayByKey_NullArray_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => ArrayExtension.FilterArray(null, new FilterByKey(55)));
        }

        [Test]
        public void FilterArrayByKey_ZeroLengthArray_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException),
                () => ArrayExtension.FilterArray(new int[] { }, new FilterByKey(55)));
        }

    }
}
