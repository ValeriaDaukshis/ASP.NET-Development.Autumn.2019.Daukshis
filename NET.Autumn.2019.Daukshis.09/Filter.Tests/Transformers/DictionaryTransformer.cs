
using System.Text;
using Filter.Interfaces;

namespace Filter.Transformers
{
    public class DictionaryTransformer : ITransformer<double,string>
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
        public string TransformToWord(double number)
        {
            if(_dictionary.ComplexDictionary.ContainsKey(number))
            {
                return _dictionary.ComplexDictionary[number];
            }
            return DigitDictionary(number.ToString());
        }
        
        private string DigitDictionary(string value)
        {
            string num = value;
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