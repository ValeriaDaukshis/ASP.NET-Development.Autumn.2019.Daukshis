﻿using NUnit.Framework;
using Task1;

namespace ArrayExtensions.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [Test]
        public void BubbleSort_CompareNumbersInWholeArray_SortedArray()
        {
            int[] actual = { 2, 4, 8, -3 };
            int[] expected = { 2, -3, 4, 8 };
            ArrayExtension.BubbleSort(actual, new CompareByModulo(), new StepIndexer(actual, actual.Length));
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleSort_CompareElementsFromZeroIndexWithStep2In2Notation_SortedArray()
        {
            int[] actual = { 5, 4, 8, 3 };
            int[] expected = { 8, 4, 5, 3 };
            ArrayExtension.BubbleSort(actual, new CompareBySymbol(2, '1'), new StepIndexer(actual, actual.Length, step: 2));
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void BubbleSort_CompareElementsFrom1IndexWithStep3To6ElementIn3Notation_SortedArray()
        {
            int[] actual = { 10, 68, 8, 25, 5, 34, 26, 3 };
            int[] expected = { 10, 68, 8, 5, 25, 34, 26, 3 };
            ArrayExtension.BubbleSort(actual, new CompareByValue(), new MultiplicityIndexer(actual, actual.Length,3,  5));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QSort_CompareElementsFromZeroIndexWithStep2In2Notation_SortedArray()
        {
            int[] actual = { 5, 1, 8, 3, 4, 6 };
            int[] expected = { 8, 1, 4, 3, 5, 6 };
            ArrayExtension.QSort(actual, new CompareBySymbol(2, '1'), new StepIndexer(actual, actual.Length-1, step: 2));
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void SortNumbers_CompareNumbersInWholeArray_SortedArray()
        {
            int[] actual = { 2, 4, 8, -3 };
            int[] expected = { 2, -3, 4, 8 };
            ArrayExtension.QSort(actual, new CompareByModulo(), new StepIndexer(actual, actual.Length));
            Assert.AreEqual(actual, expected);
        }

    }

}
