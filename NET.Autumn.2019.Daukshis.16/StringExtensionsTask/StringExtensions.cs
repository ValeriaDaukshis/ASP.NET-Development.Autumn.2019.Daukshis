using System;
using System.Collections.Generic;

namespace StringExtensionsTask
{
    public static class StringExtensions
    {
        private static Dictionary<int, int> periodTable = new Dictionary<int, int>()
        {
            { 0, 6 },
            { 1, 0 },
            { 2, 2 },
            { 3, 2 },
            { 4, 2 },
            { 5, 4 },
            { 6, 4 },
            { 7, 4 },
            { 8, 6 },
            { 9, 6 },
            //{ 10, 6 }
        };

        /// <summary>
        /// Generates the string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public static string GenerateString(string s, int n)
        {
            CheckInputData(s, n);
            
            if (s.Length == 1)
            {
                return s;
            }
            if ((s.Length == 2) && (n % 2 == 0))
            {
                return s;
            }
            if ((s.Length == 2) && (n % 2 != 0))
            {
                return s[1].ToString() + s[0];
            }
            
            var fullPeriod = periodTable[s.Length % 10];
            var countOfPeriods = n / 10;
            var count = fullPeriod + (fullPeriod * countOfPeriods);
            var countOfIterations = n != count ? n % count : n;

            unsafe
            {
                fixed (char* c = s)
                {
                    while (countOfIterations > 0)
                    {
                        int oddPointer = 2;
                        int iterations = 1;
                        int countOfOdd = (s.Length % 2) + (s.Length / 2);

                        while (countOfOdd - 1 > 0)
                        {
                            int pointer = oddPointer;
                            for (int i = 0; i < iterations; i++)
                            {
                                Swap(c, pointer, pointer - 1);
                                pointer--;
                            }

                            countOfOdd--;
                            iterations++;
                            oddPointer += 2;
                        }

                        countOfIterations--;
                    }
                }
            }

            return s;
        }

        private static void CheckInputData(string s, int n)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException();
            }

            if (n <= 0)
            {
                throw new ArgumentException();
            }
        }
        
        static unsafe void Swap(char* c, int i, int j)
        {
            var temp = c[i];
            c[i] = c[j];
            c[j] = temp;
        }
    }
}