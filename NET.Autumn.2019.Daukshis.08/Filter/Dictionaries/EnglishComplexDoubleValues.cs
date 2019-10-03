using System;
using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class EnglishComplexDoubleValues : IDoubleComplexDictionary
    {
        public Dictionary<double, string> GetComplexDictionary()
        {
            Dictionary<double, string> doubleValues = new Dictionary<double, string>()
            {
                {Double.NaN, "Not a number"},
                {Double.NegativeInfinity, "Negative infinity"},
                {Double.PositiveInfinity, "Positive infinity"}
            };
            return doubleValues;
        }
    }
}