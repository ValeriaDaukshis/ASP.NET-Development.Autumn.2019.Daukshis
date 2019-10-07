using System;
using System.Collections.Generic;
using System.Globalization;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class EnglishDictionary<T> : IDoubleDictionary
    { 
        public Dictionary<string, string> ComplexDictionary => new Dictionary<string, string>()
        {
            {Double.NaN.ToString(), "Not a number"},
            {Double.NegativeInfinity.ToString(), "Negative infinity"},
            {Double.PositiveInfinity.ToString(), "Positive infinity"}
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