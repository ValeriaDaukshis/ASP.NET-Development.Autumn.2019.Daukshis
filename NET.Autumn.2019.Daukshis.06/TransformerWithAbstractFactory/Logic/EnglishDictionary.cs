using System;
using System.Collections.Generic;
using System.Text;
using TransformerWithAbstractFactory.AbstractClasses;

namespace TransformerWithAbstractFactory.Logic
{
    public class EnglishDictionary : TransformationMethod
    {
        /// <summary>
        /// Transforms to string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Double value in word format</returns>
        public override string TransformToString(double number)
        {
            Dictionary<double, string> doubleValues = new Dictionary<double, string>()
            {
                { Double.NaN, "Not a number" },
                { Double.NegativeInfinity, "Negative infinity" },
                { Double.PositiveInfinity, "Positive infinity"} 
            };
            string num;
            try
            {
                num = doubleValues[number];
                return num;
            }
            catch (KeyNotFoundException)
            {
                num = DigitDictionary(number);
            }

            return num;
        }

        /// <summary>
        /// Digits the dictionary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Double value in word format</returns>
        private string DigitDictionary(double value)
        {  
            Dictionary<char, string> words = new Dictionary<char, string>()
            {
                { '0', "zero" },
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" },
                { '-', "minus" },
                { ',', "point" },
                { 'E', "E" },
                { '+', "plus" }
            };
            string num = value.ToString();
            var word = new StringBuilder();
            foreach (var digit in num) 
            {
                word.Append($"{words[digit]} ");
            } 
            
            word.Remove(word.Length - 1, 1);
            return word.ToString();
        } 
    }
}