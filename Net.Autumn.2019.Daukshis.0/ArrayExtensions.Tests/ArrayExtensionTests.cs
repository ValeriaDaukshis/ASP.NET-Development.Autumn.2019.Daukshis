using NUnit.Framework; 
using Task1;

namespace ArrayExtensions.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [Test]
        public void SortNumbers_CompareNumbersInWholeArray_SortedArray()
        {
            int[] actual = {2, 4, 8, -3};

            ArrayExtension.SortNumbers(actual, new AbsNumberCompare(), new WithoutIndex(actual));
            Assert.AreEqual(actual, new int[]{2, -3, 4, 8});
        }

        [Test]
        public void SortNumbers_CompareElementsFromZeroIndexWithStep2In2Notation_SortedArray()
        {
            int[] actual = { 5, 4, 8, 3 };

            ArrayExtension.SortNumbers(actual, new CompareBySymbol(2, '1'), new WithStartStepIndex(actual, 0, 2));
            Assert.AreEqual(actual, new int[] { 8, 4, 5, 3  });
        }

        [Test]
        public void SortNumbers_CompareElementsFrom1IndexWithStep3To6ElementIn3Notation_SortedArray()
        {

            int[] actual = { 4, 68, 8, 25, 5, 34, 26, 3 }; 

            ArrayExtension.SortNumbers(actual, new CompareBySymbol(3, '1'), new WithStartStepFinishIndex(1, 5, 3));
            Assert.AreEqual(actual, new int[] { 4, 5, 8, 25, 68, 34, 26, 3 });
        }

        [Test]
        public void SortNumbers_CompareArrayElementsWithStep4_SortedArray()
        {

            int[] actual = { 34, 68, 8, 25, 4, 26, 5, 3 };

            ArrayExtension.SortNumbers(actual, new SimpleNumberCompare(), new WithStepIndex(actual,4));
            Assert.AreEqual(actual, new int[] { 4, 68, 8, 25, 34, 26, 5, 3 });
        }
    }
}
