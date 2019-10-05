using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Filter.Interfaces;

namespace Filter.Transformers
{
    public class DictionaryTransformer : ITransformer
    {
        private readonly IDoubleComplexDictionary _complexDictionary;
        private readonly IDoubleSimpleDictionary _simpleDictionary;
        public DictionaryTransformer(IDoubleComplexDictionary complexDictionary, IDoubleSimpleDictionary simpleDictionary)
        {
            this._complexDictionary = complexDictionary;
            this._simpleDictionary = simpleDictionary;
        }
        /// <summary>
        /// Transforms to string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Double value in word format</returns>
        public string TransformToWord<T>(T number) where T : struct
        {
            string num;
            try
            {
                num = _complexDictionary.GetComplexDictionary()[number.ToString()];
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
                word.Append($"{_simpleDictionary.GetSimpleDictionary()[digit]} ");
            } 
            
            word.Remove(word.Length - 1, 1);
            return word.ToString();
        } 
    }
}