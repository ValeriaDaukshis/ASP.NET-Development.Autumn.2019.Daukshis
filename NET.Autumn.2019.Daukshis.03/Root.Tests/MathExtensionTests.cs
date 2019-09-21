using System;
using NUnit.Framework; 

namespace Root.Tests
{
    [TestFixture]
    public class MathExtensionTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        public double FindNthRoot_RootExpected(double number, int root, double accuracy)
             => FindNthRootClass.MathExtension.FindNthRoot(number, root, accuracy);

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_ArgumentNullException(double number, int root, double accuracy)
        {
            Assert.Throws(typeof(ArgumentException),
            () => FindNthRootClass.MathExtension.FindNthRoot(number, root, accuracy));
        }
        
    }
}
