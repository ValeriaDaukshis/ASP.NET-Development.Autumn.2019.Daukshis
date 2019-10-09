using System;
using System.Collections.Generic;
using System.Globalization;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class EnglishDictionary : IDoubleDictionary
    { 
        public Dictionary<double, string> ComplexDictionary => new Dictionary<double, string>()
        {
            {Double.NaN, "Not a number"},
            {Double.NegativeInfinity, "Negative infinity"},
            {Double.PositiveInfinity, "Positive infinity"}
        };
       
        public Dictionary<char, string> SimpleDictionary => new Dictionary<char, string>()
        {
            {'0', "zero"},
            {'1', "one"},
            {'2', "two"},
            {'3', "three"},
            {'4', "four"},
            {'5', "five"},
            {'6', "six"},
            {'7', "seven"},
            {'8', "eight"},
            {'9', "nine"},
            {'-', "minus"},
            {',', "point"},
            {'E', "E"},
            {'+', "plus"}
        }; 
    }
}