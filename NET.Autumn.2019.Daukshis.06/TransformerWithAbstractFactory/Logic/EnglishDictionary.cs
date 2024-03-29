﻿using System;
using System.Collections.Generic;
using System.Text;
using TransformerWithAbstractFactory.AbstractClasses;
using TransformerWithAbstractFactory.Dictionaries;

namespace TransformerWithAbstractFactory.Logic
{
    public class EnglishDictionary : TransformationMethod
    {
        private IDoubleComplexDictionary _complexDictionary;
        private IDoubleSimpleDictionary _simpleDictionary;
        public EnglishDictionary(IDoubleComplexDictionary complexDictionary, IDoubleSimpleDictionary simpleDictionary)
        {
            this._complexDictionary = complexDictionary;
            this._simpleDictionary = simpleDictionary;
        }
        /// <summary>
        /// Transforms to string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Double value in word format</returns>
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