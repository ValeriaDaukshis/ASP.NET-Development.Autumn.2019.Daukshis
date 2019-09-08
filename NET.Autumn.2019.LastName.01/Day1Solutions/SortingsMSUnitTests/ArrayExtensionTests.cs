using System;
using ArraySortings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortingsMSUnitTests
{
    [TestClass]
    public class ArrayExtensionTests
    {
        [TestMethod]
        public void QSort_UnsortedArray_SortedArrayReturned()
        {
            int[] actual = { 5, 4, 8, 0, 25, 64, -5, -8, 125 };
            int[] expected = { -8, -5, 0, 4, 5, 8, 25, 64, 125 };
            ArrayExtension.QSort(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QSort_NullArray_ArgumentNullExceptionReturned()
        {
            ArrayExtension.QSort(null); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QSort_ZeroArray_ArgumentExceptionReturned()
        {
            int[] actual = { };
            ArrayExtension.QSort(actual);
        }

        [TestMethod]
        public void QSort_BigLengthArray_SortedArrayReturned()
        {
            int[] actual = new int[10000];
            int[] expected = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < 10000; i++)
            {
                actual[i] = rand.Next(0, 10000);
                expected[i] = actual[i];
            }
            ArrayExtension.QSort(actual);
            Array.Sort(expected, 0, 10000);
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void MergeSort_UnsortedArray_SortedArrayReturned()
        {
            int[] actual = { 5, 4, 8, 0, 25, 64, -5 };
            int[] expected = { -5, 0, 4, 5, 8, 25, 64 };
            ArrayExtension.MergeSort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MergeSor_BigLengthArray_SortedArrayReturned()
        {
            int[] actual = new int[10000];
            int[] expected = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < 10000; i++)
            {
                actual[i] = rand.Next(0, 10000);
                expected[i] = actual[i];
            }
            ArrayExtension.MergeSort(actual);
            Array.Sort(expected, 0, 10000);
            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_NullArray_ArgumentNullExceptionReturned()
        {
            ArrayExtension.MergeSort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_ZeroArray_ArgumentExceptionReturned()
        {
            int[] actual = { };
            ArrayExtension.MergeSort(actual);
        }
    }
}
