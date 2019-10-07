using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Filter.Interfaces;

namespace Filter.Transformers
{
    public class DictionaryTransformer : ITransformer
    {
        private readonly IDoubleDictionary _dictionary;
        public DictionaryTransformer(IDoubleDictionary dictionary)
        {
            this._dictionary = dictionary ?? throw new ArgumentNullException();
        }
        /// <summary>
        /// Transforms to string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Double value in word format</returns>
        public string TransformToWord(double number)
        {
            string num;
            try
            {
                num = _dictionary.ComplexDictionary[number];
                return num;
            }
            catch (KeyNotFoundException)
            {
                num = DigitDictionary(number);
            }

            return num;
        }
        
        private string DigitDictionary(double value)
        {
            string num = value.ToString();
            var word = new StringBuilder();
            foreach (var digit in num) 
            {
                word.Append($"{_dictionary.SimpleDictionary[digit]} ");
            } 
            
            word.Remove(word.Length - 1, 1);
            return word.ToString();
        } 
    }
}