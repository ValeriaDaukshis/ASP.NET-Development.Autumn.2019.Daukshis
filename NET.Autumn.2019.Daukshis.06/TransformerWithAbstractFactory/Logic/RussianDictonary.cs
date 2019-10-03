using System.Collections.Generic;
using System.Text;
using TransformerWithAbstractFactory.AbstractClasses;
using TransformerWithAbstractFactory.Dictionaries;

namespace TransformerWithAbstractFactory.Logic
{
    public class RussianDictionary : TransformationMethod
    {
        private IDoubleComplexDictionary _complexDictionary;
        private IDoubleSimpleDictionary _simpleDictionary;
        public RussianDictionary(IDoubleComplexDictionary complexDictionary, IDoubleSimpleDictionary simpleDictionary)
        {
            this._complexDictionary = complexDictionary;
            this._simpleDictionary = simpleDictionary;
        }
        public override string TransformToString(double number)
        {
            string num;
            try
            {
                num = _complexDictionary.GetComplexDictionary()[number];
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
                word.Append($"{_simpleDictionary.GetSimpleDictionary()[digit]} ");
            } 
            
            word.Remove(word.Length - 1, 1);
            return word.ToString();
        } 
    }
}