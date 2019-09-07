using System;
using Day1Task3;
using NUnit.Framework;

namespace SortingsLibraryTests
{
    [TestFixture]
    public class SortingsTests
    {
        [Test]
        public void QSortTest()
        {
            int[] actual = { 5, 4, 8, 0, 25, 64, -5 };
            int[] expected = { -5, 0, 4, 5, 8, 25, 64 };
            Sortings.QSort(actual);

           Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QSortNullTest()
        {
            Assert.Throws(typeof(ArgumentNullException),
                ()=>Sortings.QSort(null));
        }

        [Test]
        public void QSortZeroTest()
        {
            int[] actual = { };
            Assert.Throws(typeof(ArgumentException),
                () => Sortings.QSort(actual));
        }

        [Test]
        public void MergeSortTest()
        {
            int[] actual = { 5, 4, 8, 0, 25, 64, -5 };
            int[] expected = { -5, 0, 4, 5, 8, 25, 64 };
            Sortings.MergeSort(actual);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void MergeSortNullTest()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => Sortings.MergeSort(null));
        }

        [Test]
        public void MergeSortZeroTest()
        {
            int[] actual = { };
            Assert.Throws(typeof(ArgumentException),
                () => Sortings.MergeSort(actual));
        }
    }
}
