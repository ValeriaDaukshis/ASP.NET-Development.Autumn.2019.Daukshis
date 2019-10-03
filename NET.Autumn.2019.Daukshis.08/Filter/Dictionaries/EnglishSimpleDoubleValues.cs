using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class EnglishSimpleDoubleValues : IDoubleSimpleDictionary
    {
        public Dictionary<char, string> GetSimpleDictionary()
        {
            Dictionary<char, string> doubleValues = new Dictionary<char, string>()
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
            return doubleValues;
        }
    }
}