using System;
using System.Collections.Generic;
using System.Globalization;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class EnglishComplexDoubleValues : IDoubleComplexDictionary
    {
        /// <summary>
        /// Gets the complex dictionary.
        /// </summary>
        /// <returns>English <double, string> dictionary </returns>
        public Dictionary<string, string> GetComplexDictionary()
        {
            Dictionary<string, string> doubleValues = new Dictionary<string, string>()
            {
                {Double.NaN.ToString(), "Not a number"},
                {Double.NegativeInfinity.ToString(), "Negative infinity"},
                {Double.PositiveInfinity.ToString(), "Positive infinity"}
            };
            return doubleValues;
        }
    }
}