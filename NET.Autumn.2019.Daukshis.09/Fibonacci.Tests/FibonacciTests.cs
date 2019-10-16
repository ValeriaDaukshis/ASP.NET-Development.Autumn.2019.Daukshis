using System;
using System.Numerics;
using NUnit.Framework;

namespace Fibonacci.Tests
{
    public class FibonacciTests
    {
        [TestCase(5, new long[]{0, 1, 1, 2, 3})]
        [TestCase(10, new long[]{0, 1, 1, 2, 3, 5, 8, 13, 21, 34})]
        [TestCase(10, new long[]{0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368})]
        public void GetFibonacciNumbers_ReturnNthElement(int limit, long[] array)
        {
            int i = 0;
            foreach (var a in NumberExtensions.GetFibonacciNumbers(limit))
            {
                Assert.AreEqual(a, new BigInteger(array[i]) );
                ++i;
            }
        }
        
        [Test]
        public void GetFibonacciNumbers_SetBibLimit_ArgumentException()
        {
            Assert.Throws<OverflowException>(
                delegate
                {
                    foreach (var a in NumberExtensions.GetFibonacciNumbers(int.MaxValue))
                    {
                    }
                });
        }
    }
}