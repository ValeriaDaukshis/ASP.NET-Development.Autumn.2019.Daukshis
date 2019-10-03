using System.Runtime.InteropServices;
using System.Text;
using Filter.Interfaces;

namespace Filter.Transformers
{
    public class TransformerTo2Notation : ITransformer
    {
        public string TransformToWord(double doubleNumber)
        {
            Number num = new Number(doubleNumber);
            long value = num.longValue;
            StringBuilder builder = new StringBuilder(64);
            for (int i = 0; i < 64; i++)
            {
                string digit = (value & 1).ToString();
                
                builder.Insert(0, digit);
                value >>= 1;
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