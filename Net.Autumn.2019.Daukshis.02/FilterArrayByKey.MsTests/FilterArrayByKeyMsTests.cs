using Microsoft.VisualStudio.TestTools.UnitTesting;
using Filter;
using System;

namespace FilterArrayByKey.MsTests
{
    [TestClass]
    public class FilterArrayByKeyMsTests
    {
        [TestMethod]
        public void FilterArrayByKey_Value0AndNonZeroLengthArray_FilteredArrayExpected()
        {
            int[] actual = ArrayExtension.FilterArray(new[] { 2212332, 1405644, -1236674 }, new FilterByKey(0));
            int[] expected = { 1405644 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterArrayByKey_Value7AndNonZeroLengthArray_FilteredArrayExpected()
        {
            int[] actual = ArrayExtension.FilterArray(new[] { -27, 173, 371132, 7556, 7243, 10017 }, new FilterByKey(7));
            int[] expected = { -27, 173, 371132, 7556, 7243, 10017 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterArrayByKey_NullArray_ArgumentNullException()
        {
            ArrayExtension.FilterArray(null, new FilterByKey(55));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterArrayByKey_ZeroLengthArray_ArgumentException()
        {
            ArrayExtension.FilterArray(new int[] { }, new FilterByKey(55));
        }
    }
}
