using System;
using NUnit.Framework;
using ArrayExtensions;

namespace ArrayExtensions.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            int[] actual = {2, 4, 8, 3};

            Task1.ArrayExtension.SortNumbers(actual, 2);
            Assert.AreEqual(actual, new int[]{2,4,8,3});
        }
    }
}
