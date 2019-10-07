using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Fibonacci.Tests
{
    public class FibonacciTests
    {
        //0 1 1 2 3 
        [TestCase(5, ExpectedResult = 3)]
        [TestCase(10, ExpectedResult = 34)]
        [TestCase(25, ExpectedResult = 46368)]
        public int GetFibonacciNumbers_ReturnNthElement(int limit)
        {
            int result = 0;
            foreach (var a in NumberExtensions.GetFibonacciNumbers(limit))
                result = a;

            return result;
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