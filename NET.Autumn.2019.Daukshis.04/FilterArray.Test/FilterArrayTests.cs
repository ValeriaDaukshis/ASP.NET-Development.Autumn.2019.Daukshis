using System;
using Filters;
using NUnit.Framework;

namespace FilterArray.Test
{
    [TestFixture]
    public class FilterArrayTests
    {
        [TestCase(new[] { 121, 1405644, -1236672 }, 4, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult =
         new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        public int[] FilterArray_ArrayAndValue_FilteredArrayExpected(int[] array, int num)
            => ArrayExtension.FilterArray(array, new FilterByKey(num));

        [TestCase(new[] { 121, 1405644, -1236672 }, ExpectedResult = new[] { 121 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005, 111 }, ExpectedResult = new[] { 1001, 111 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, ExpectedResult = new[] { 7, 2, 5, 5, -1, -1, 2 })]
        public int[] FilterArray_Array_ArrayWithPalindromValuesExpected(int[] array)
            => ArrayExtension.FilterArray(array, new FilterByPalindrome());

        [TestCase(new[] { 121, 1405644, -1236672 }, ExpectedResult = new[] { 1405644, -1236672 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7244, 10018 }, ExpectedResult =
            new[] { 371132, 7556, 7244, 10018 })]
        [TestCase(new[] { 7, 3, 5, 5, -1, -1, 9 }, ExpectedResult = new int[0])]
        public int[] FilterArray_Array_ArrayWithEvenValuesExpected(int[] array)
            => ArrayExtension.FilterArray(array, new FilterEvenElements());

        [Test]
        public void FilterArray_NullArray_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => ArrayExtension.FilterArray(null, new FilterByKey(55)));
        }

        [Test]
        public void FilterArray_ZeroLengthArray_ArgumentException() =>
            Assert.Throws(typeof(ArgumentException),
                () => ArrayExtension.FilterArray(new int[] { }, new FilterByPalindrome()));
        
    }
}