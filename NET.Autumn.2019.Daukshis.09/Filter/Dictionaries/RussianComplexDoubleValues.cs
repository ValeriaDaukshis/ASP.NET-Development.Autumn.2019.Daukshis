using System;
using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class RussianComplexDoubleValues : IDoubleComplexDictionary
    {
        /// <summary>
        /// Gets the complex dictionary.
        /// </summary>
        /// <returns>Russian <double, string> dictionary</returns>
        public Dictionary<string, string> GetComplexDictionary()
        {
            Dictionary<string, string> doubleValues = new Dictionary<string, string>()
            {
                {Double.NaN.ToString(), "Не число"},
                {Double.NegativeInfinity.ToString(), "Отрицательная бесконечность"},
                {Double.PositiveInfinity.ToString(), "Положительная бесконечность"}
            };
            return doubleValues;
        }
    }
}