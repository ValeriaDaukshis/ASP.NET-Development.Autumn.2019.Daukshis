using System;
using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class RussianComplexDoubleValues : IDoubleComplexDictionary
    {
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