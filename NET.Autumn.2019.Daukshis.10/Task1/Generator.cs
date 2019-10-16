using System;
using System.Collections;
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
        public static IEnumerable<int> GenerateSimpleNumbers(int upperLimit)
        {
            BitArray composite = new BitArray(upperLimit);
            
            int generatorLimit= (int)Math.Sqrt(upperLimit);
            for (int p = 2; p <= generatorLimit; ++p) 
            {
                if (composite[p])
                {
                    continue;
                } 

                yield return p;

                for (int i = p * p; i < upperLimit; i = i + p)
                {
                    composite.Set(i, true);
                    composite[i] = true;
                }
            }
            
            for (int p = generatorLimit + 1; p < upperLimit; ++p) 
            {
                if (!composite[p]) 
                    yield return p;
            }
        }
    }
}