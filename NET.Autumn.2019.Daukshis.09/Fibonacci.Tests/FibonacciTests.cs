using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Fibonacci.Tests
{
    public class FibonacciTests
    {
        [TestCase(5, ExpectedResult = 3)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(10, ExpectedResult = 34)]
        [TestCase(25, ExpectedResult = 46368)]
        public int GetFibonacciNumbers(int limit)
        {
            int result = 0;
            foreach (var a in NumberExtensions.GetFibonacciNumbers(limit))
                result = a;

            return result;
        }
        [Test]
        public void FindMaximumItem_ZeroLengthArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(
                delegate
                {
                    foreach (var a in NumberExtensions.GetFibonacciNumbers(int.MaxValue))
                    {
                    }
                });
        }
    }
}