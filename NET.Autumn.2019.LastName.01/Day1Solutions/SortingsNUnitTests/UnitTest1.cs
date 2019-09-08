using System; 
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void QSortTest()
        {
            int[] actual = { 5, 4, 8, 0, 25, 64, -5 };
            int[] expected = { -5, 0, 4, 5, 8, 25, 64 };
            ArrayExtension.QSort(actual);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}