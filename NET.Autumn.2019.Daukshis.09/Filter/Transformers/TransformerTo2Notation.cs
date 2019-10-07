using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Filter.Interfaces;

namespace Filter.Transformers
{
    public class TransformerTo2Notation : ITransformer<double,string>
    {
        /// <summary>
        /// Transforms to word.
        /// </summary>
        /// <param name="doubleNumber">The double number.</param>
        /// <returns>Double value is string representation</returns>
        public string TransformToWord(double doubleNumber) 
        {
            Number num = new Number(doubleNumber);
            long value = num.longValue;
            StringBuilder builder = new StringBuilder(64);
            for (int i = 63; i >= 0; i--)
            {
                string digit = ((value & (1<<63))>>63).ToString() == "0" ? "0" :"1";
                builder.Append(digit);
                value <<= 1;
            }

            return builder.ToString(); 
        }
        
        [StructLayout(LayoutKind.Explicit)]
        private struct Number
        {
            [FieldOffset(0)] 
            public long longValue;
            
            [FieldOffset(0)] 
            private double value;

            public Number(double number)
            {
                longValue = 0;
                value = number; 
            }
        }
    }
}