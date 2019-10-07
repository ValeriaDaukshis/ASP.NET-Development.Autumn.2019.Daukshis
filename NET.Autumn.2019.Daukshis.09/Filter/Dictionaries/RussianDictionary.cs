using System;
using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.Dictionaries
{
        public class RussianDictionary<T> : IDoubleDictionary
        {
            public Dictionary<string, string> ComplexDictionary => new Dictionary<string, string>()
            {
                {Double.NaN.ToString(), "Не число"},
                {Double.NegativeInfinity.ToString(), "Отрицательная бесконечность"},
                {Double.PositiveInfinity.ToString(), "Положительная бесконечность"}
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