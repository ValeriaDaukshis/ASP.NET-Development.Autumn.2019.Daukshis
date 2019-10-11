using System;
using System.Collections.Generic;

namespace Task1
{
    public static class Generator
    {
        /// <summary>
        /// GenerateSimpleNumbers
        /// </summary>
        /// <param name="upperLimit">limit</param>
        /// <returns>Simple numbers from 1 to upperLimit</returns>
        public static IEnumerable<ulong> GenerateSimpleNumbers(ulong upperLimit)
        {
            bool[] composite = new bool[upperLimit];
            
            ulong generatorLimit= (ulong)Math.Sqrt(upperLimit);
            for (ulong p = 2; p <= generatorLimit; ++p) 
            {
                if (composite[p])
                {
                    continue;
                } 

                yield return p;

                try
                {
                    for (ulong i = checked(p * p); i < upperLimit; i = checked(i + p))
                    {
                        composite[i] = true;
                    }
                }
                catch (StackOverflowException ex)
                {
                    Console.WriteLine(ex);
                }
               
            }
            
            for (ulong p = generatorLimit + 1; p < upperLimit; ++p) 
            {
                if (!composite[p]) 
                    yield return p;
            }
        }
    }
}