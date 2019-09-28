using System.Runtime.InteropServices;
using System.Text;
using TransformerWithAbstractFactory.AbstractClasses;

namespace TransformerWithAbstractFactory.Logic
{
    public class DoubleToStringConverter : TransformationMethod
    {
        /// <summary>
        /// Transforms to string.
        /// </summary>
        /// <param name="doubleNumber">The double number.</param>
        /// <returns> String representation of double value in 2 notation</returns>
        public override string TransformToString(double doubleNumber)
        {
            Number num = new Number(doubleNumber);
            long value = num.longValue;
            StringBuilder builder = new StringBuilder();
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