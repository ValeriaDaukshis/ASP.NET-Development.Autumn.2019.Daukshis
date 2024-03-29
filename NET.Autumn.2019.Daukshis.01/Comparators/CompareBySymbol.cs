﻿using System;
using System.Collections.Generic; 

namespace Task1
{
    public class CompareBySymbol : IComparer<int>
    {
        private readonly int  _toBase;
        private readonly char _symbol;

        public CompareBySymbol(int toBase, char symbol)
        {
            if(toBase < 2 || toBase > 16)
                throw new ArgumentException("Notation must be upper 2 and under 16");
            if(symbol < '0' || symbol > 'F')
                throw new ArgumentException("The available symbols are '0123456789ABCDEF'");
            _toBase = toBase;
            _symbol = symbol;
        }

        /// <summary>
        /// Compares the specified number1.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>comparison result</returns>
        public int Compare(int number1, int number2)
        {
            string convertedNumber1 = Converter.ConvertToBase(number1, _toBase);
            string convertedNumber2 = Converter.ConvertToBase(number2, _toBase);

            int counter1 = Counter(convertedNumber1);
            int counter2 = Counter(convertedNumber2);

            return counter1.CompareTo(counter2);
        }

        /// <summary>
        /// Counters the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>number of occurrences of an element</returns>
        private int Counter(string number)
        {
            int counter = 0;
            for (int i = 0; i < number.Length; i++)
                if (number[i] == _symbol)
                    counter++;

            return counter;
        }

    }
}
