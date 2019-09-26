using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformer
{
    public class Transform : ITransformer
    {
        public string TransformToWords(double number)
        {
            Dictionary<double, string> doubleValues = new Dictionary<double, string>()
            {
                { Double.NaN, "Not a number" },
                { Double.NegativeInfinity, "Negative infinity" },
                { Double.PositiveInfinity, "Positive infinity"} 
            };
            
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

            string num;
            try
            {
                num = doubleValues[number];
                return num;
            }
            catch (KeyNotFoundException)
            {
                num = number.ToString();
            }
            
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
