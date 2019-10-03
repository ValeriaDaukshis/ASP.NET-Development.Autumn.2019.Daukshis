using System;
using System.Collections.Generic;

namespace TransformerWithAbstractFactory.Dictionaries
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

    public class RussianSimpleDoubleValues : IDoubleSimpleDictionary
    {
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