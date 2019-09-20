using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InsertNumber;

namespace InsertNumberIntoAnother.MsTests
{
    [TestClass]
    public class InsertNumberIntoAnotherMsTests
    {
        [TestMethod]
        public void InsertNumberIntoAnother_InsertNumber655Into2728From3to8Indexes_NewNumberExpected()
        {
            int actual = NumbersExtension.InsertNumberIntoAnother(2728, 655, 3, 8);
            int expected = 2680;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberIntoAnother_InserBigtNumberIntoAnotheFrom0to31Indexes_NewNumberExpected()
        {
            int actual = NumbersExtension.InsertNumberIntoAnother(-55465467, 345346, 0, 31);
            int expected = 345346;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberIntoAnother_InsertNumberIntoAnotheFromMinus1to3Indexes_ArgumentOutOfRangeException()
        {
            NumbersExtension.InsertNumberIntoAnother(8, 15, -1, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberIntoAnother_InsertNumberIntoAnotheFromMinus1to3Indexes_ArgumentException()
        {
            NumbersExtension.InsertNumberIntoAnother(8, 15, 8, 3);
        }
    }
}
