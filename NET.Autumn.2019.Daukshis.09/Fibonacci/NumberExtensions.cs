using System;
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
        public static IEnumerable<ulong> GetFibonacciNumbers(int limit)
        {
            if(limit <= 0)
                throw new ArgumentException();
            
            ulong x0 = 0, x1 = 1;
            yield return x0;
            yield return x1;
            for (int i = 2; i < limit; i++)
            {
                ulong result = x1;
                try
                {
                    result = checked(x0 + x1);
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine(e);
                }
                    
                yield return result;
                x0 = x1;
                x1 = result;
            }
        }
    }
}