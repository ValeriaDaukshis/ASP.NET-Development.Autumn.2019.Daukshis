using System;
using ArraySortings;
using NUnit.Framework; 

namespace SortingsNUnitTest
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [Test]
        public void QSort_UnsortedArray_SortedArrayReturned()
        {
            int[] actual = { 5, 4, 8, 0, 25, 64, -5 };
            int[] expected = { -5, 0, 4, 5, 8, 25, 64 };
            ArrayExtension.QSort(actual); 
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QSort_NullArray_ArgumentNullExceptionReturned()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => ArrayExtension.QSort(null));
        }

        [Test]
        public void QSort_ZeroArray_ArgumentExceptionReturned()
        {
            int[] actual = { };
            Assert.Throws(typeof(ArgumentException),
                () => ArrayExtension.QSort(actual));
        }

        [Test]
        public void QSort_BigLengthArray_SortedArrayReturned()
        {
            int[] actual = new int[10000];
            int[] expected = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < 10000; i++)
            {
                actual[i] = rand.Next(0, 10000) ;
                expected[i] = actual[i];
            }
            ArrayExtension.QSort(actual); 
            Array.Sort(expected, 0, 10000);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void MergeSort_UnsortedArray_SortedArrayReturned()
        {
            int[] actual = { 5, 4, 8, 0, 25, 64, -5 };
            int[] expected = { -5, 0, 4, 5, 8, 25, 64 };
            ArrayExtension.MergeSort(actual);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void MergeSort_NullArray_ArgumentNullExceptionReturned()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => ArrayExtension.MergeSort(null));
        }

        [Test]
        public void MergeSort_ZeroArray_ArgumentExceptionReturned()
        {
            int[] actual = { };
            Assert.Throws(typeof(ArgumentException),
                () => ArrayExtension.MergeSort(actual));
        }
    }
}
