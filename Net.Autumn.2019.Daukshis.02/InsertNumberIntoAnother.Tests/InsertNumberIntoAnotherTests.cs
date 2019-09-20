using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsertNumber;
using NUnit.Framework;

namespace InsertNumberIntoAnother.Tests
{
    [TestFixture]
    public class InsertNumberIntoAnotherTests
    {
        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(216, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        public int InsertNumberIntoAnother_InsertNumberIntoAnotherFromitojIndexes_NewNumberExpected(int initNum, int insertedNum, int i, int j)
            => NumbersExtension.InsertNumberIntoAnother(initNum, insertedNum, i, j);

        [Test]
        public void InsertNumberIntoAnother_InsertNumberIntoAnotherFrom8To3Indexes_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException),
                () => NumbersExtension.InsertNumberIntoAnother(8, 15, 8, 3));
        }

        [Test]
        public void InsertNumberIntoAnother_InsertNumberIntoAnotherFromMinus1To3Indexes_ArgumentOutOfRangeException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException),
                () => NumbersExtension.InsertNumberIntoAnother(8, 15, -1, 3));
        }
        [Test]
        public void InsertNumberIntoAnother_InsertNumberIntoAnotherFrom32To32Indexes_ArgumentOutOfRangeException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException),
                () => NumbersExtension.InsertNumberIntoAnother(8, 15, 32, 32));
        }
        [Test]
        public void InsertNumberIntoAnother_InsertNumberIntoAnotherFrom0To32Indexes_ArgumentOutOfRangeException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException),
                () => NumbersExtension.InsertNumberIntoAnother(8, 15, 0, 32));
        }
    }
}
