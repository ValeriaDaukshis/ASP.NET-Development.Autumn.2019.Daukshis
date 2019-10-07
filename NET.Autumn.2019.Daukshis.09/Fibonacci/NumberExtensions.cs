using System;
using System.Collections.Generic;

namespace Fibonacci
{
    public static class NumberExtensions
    {
        /// <summary>
        /// GetFibonacciNumbers
        /// </summary>
        /// <param name="limit">count of numbers</param>
        /// <returns>Fibonacci number</returns>
        public static IEnumerable<int> GetFibonacciNumbers(int limit)
        {
            yield return 0;
            yield return 1;
            int x0 = 0;
            int x1 = 1;
            for (int i = 2; i < limit; i++)
            {
                int result = x1;
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