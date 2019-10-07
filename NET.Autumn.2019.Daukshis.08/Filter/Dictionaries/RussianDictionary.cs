using System;
using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
    public class RussianDictionary : IDoubleDictionary
    {
        public Dictionary<double, string> ComplexDictionary => new Dictionary<double, string>()
            {
                {Double.NaN, "Не число"},
                {Double.NegativeInfinity, "Отрицательная бесконечность"},
                {Double.PositiveInfinity, "Положительная бесконечность"}
            };
            
        public Dictionary<char, string> SimpleDictionary => new Dictionary<char, string>()
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
    }
}