using System;
using FindMaxRecursive;
using NUnit.Framework;

namespace FindMaximumItem.Tests
{
    [TestFixture]
    public class FindMaximumItemTests
    {
        [TestCase(new int[] { 0, 15, 32, 125, -10, 64, 29 }, ExpectedResult = 125)]
        [TestCase(new int[] { -100, -20, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] {145, -89, 145, 145, 33}, ExpectedResult = 145)]
        [TestCase(new int[] {-1}, ExpectedResult = -1)]
        public int FindMaximumItem_Array_MaxNumberInArray(int[] actual)
            => ArrayExtension.FindMaximumItem(actual);

        [Test]
        public void FindMaximumItem_ZeroLengthArray_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException),
                () => ArrayExtension.FindMaximumItem(new int[] { }));
        }

        [Test]
        public void FindMaximumItem_ZeroLengthArray_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => ArrayExtension.FindMaximumItem(null));
        }

    }
}
