using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class RussianSimpleDoubleValues : IDoubleSimpleDictionary
    {
        /// <summary>
        /// Gets the simple dictionary.
        /// </summary>
        /// <returns>Russian <char, string> dictionary</returns>
        public Dictionary<char, string> GetSimpleDictionary()
        {
            Dictionary<char, string> doubleValues = new Dictionary<char, string>()
            {
                {'0', "ноль"},
                {'1', "один"},
                {'2', "два"},
                {'3', "три"},
                {'4', "четыре"},
                {'5', "пять"},
                {'6', "шесть"},
                {'7', "семь"},
                {'8', "восемь"},
                {'9', "девять"},
                {'-', "минус"},
                {',', "точка"},
                {'E', "E"},
                {'+', "плюс"}
            };
            return doubleValues;
        }
    }
}