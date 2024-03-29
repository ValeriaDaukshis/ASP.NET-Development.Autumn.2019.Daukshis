﻿using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fibonacci
{
    public static class NumberExtensions
    {
        /// <summary>
        /// GetFibonacciNumbers
        /// </summary>
        /// <param name="limit">count of numbers</param>
        /// <returns>Fibonacci number</returns>
        public static IEnumerable<BigInteger> GetFibonacciNumbers(int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException();
            }
            
            BigInteger x0 = 0, x1 = 1;
            yield return x0;
            yield return x1;
            for (int i = 2; i < limit; i++)
            {
                BigInteger result = x1;
                result = x0 + x1;
                yield return result;
                
                x0 = x1;
                x1 = result;
            }
        }
    }
}