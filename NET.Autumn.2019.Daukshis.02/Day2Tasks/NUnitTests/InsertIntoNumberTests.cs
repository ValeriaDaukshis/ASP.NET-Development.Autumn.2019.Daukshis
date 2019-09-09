using System;
using System.Collections;
using NUnit.Framework;
using IndexSearchTask;
using InsertNumberTask;
using NumbersList;
using RecursiveSearchTasks;

namespace NUnitTests
{
    [TestFixture]
    public class InsertIntoNumberTests
    {
        [Test]
        public void InsertNumber_Insert8and15From0To0Position_9Expected()
        {
            int actual = InsertIntoNumber.InsertNumber(8, 15, 0, 0);
            int expected = 9;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void InsertNumber_Insert8and15From3To8Position_120Expected()
        {
            int actual = InsertIntoNumber.InsertNumber(8, 15, 3, 8);
            int expected = 120;
            Assert.AreEqual(actual, expected);
        }
    }

    [TestFixture]
    public class IndexSearchTests
    {
        [Test]
        public void FindIndex_UsualArray_34Expected()
        {
            object actual = IndexSearch.FindIndex(new int[] {0, 25, 34, 10, 0, 15});
            object expected = 34;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindIndex_UsualArray_NullExpected()
        {
            object actual = IndexSearch.FindIndex(new int[] { 0, 26, 34, 10, 0, 15 });
            object expected = null;
            Assert.AreEqual(expected, actual);
        }

    }

    [TestFixture]
    public class RecursiveSearchTests
    {
        [Test]
        public void FindIndex_SimpleArray_125Expected()
        {
            int actual = RecursiveSearch.FindBiggestNumber(new int[] { 0, 15, 32, 125, -10, 64, 29 });
            int expected = 125;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindIndex_ZeroLengthArray_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException),
                () => RecursiveSearch.FindBiggestNumber(new int[] { }));
        } 
    }

    [TestFixture]
    public class FilterTests
    {
        [Test]
        public void FilterArrayByKey_SimpleArray_FilteredArrayExpected()
        {
            ArrayList actual = Filter.FilterArrayByKey(new int[] { 25, 58, 36, 9, 1 }, 5);
            ArrayList expected = new ArrayList();
            expected.AddRange(new int[] { 25, 58 });
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void FilterArrayByKey_SimpleArray_ZeroArrayExpected()
        {
            ArrayList actual = Filter.FilterArrayByKey(new int[] { 25, 58, 36, 9, 1 }, 0);
            ArrayList expected = new ArrayList();
            expected.AddRange(new int[] { });
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void FilterArrayByKey_NullArray_NullReferenceException()
        {
            Assert.Throws(typeof(NullReferenceException),
                () => Filter.FilterArrayByKey(null, 5));
        } 
    }
}
