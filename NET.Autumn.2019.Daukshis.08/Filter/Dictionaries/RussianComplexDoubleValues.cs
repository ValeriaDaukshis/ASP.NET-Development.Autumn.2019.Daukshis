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
        public Dictionary<double, string> GetComplexDictionary()
        {
            Dictionary<double, string> doubleValues = new Dictionary<double, string>()
            {
                {Double.NaN, "Не число"},
                {Double.NegativeInfinity, "Отрицательная бесконечность"},
                {Double.PositiveInfinity, "Положительная бесконечность"}
            };
            return doubleValues;
        }
    }
}