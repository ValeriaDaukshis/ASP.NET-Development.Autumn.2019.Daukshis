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
            int[] actual = ArrayExtension.FilterArrayByKey(new[] { 2212332, 1405644, -1236674 }, 0);
            int[] expected = { 1405644 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterArrayByKey_Value7AndNonZeroLengthArray_FilteredArrayExpected()
        {
            int[] actual = ArrayExtension.FilterArrayByKey(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7);
            int[] expected = { -27, 173, 371132, 7556, 7243, 10017 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterArrayByKey_NullArray_ArgumentNullException()
        {
            ArrayExtension.FilterArrayByKey(null, 55);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterArrayByKey_ZeroLengthArray_ArgumentException()
        {
            ArrayExtension.FilterArrayByKey(new int[] { }, 55);
        }
    }
}
