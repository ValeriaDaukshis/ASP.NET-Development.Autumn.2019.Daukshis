using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Filter.Interfaces;

namespace Filter.Transformers
{
    public class DictionaryTransformer<T> : ITransformer<T,string>
    {
        private readonly IDoubleDictionary _dictionary;
        public DictionaryTransformer(IDoubleDictionary dictionary)
        {
            this._dictionary = dictionary;
        }

        /// <summary>
        /// Transforms to string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Double value in word format</returns>
        public string TransformToWord(T number)
        {
            string num;
            try
            {
                num = _dictionary.ComplexDictionary[number.ToString()];
                return num;
            }
            catch (KeyNotFoundException)
            {
                num = DigitDictionary(number.ToString());
            }

            return num;
        }
        
        private string DigitDictionary(string value)
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