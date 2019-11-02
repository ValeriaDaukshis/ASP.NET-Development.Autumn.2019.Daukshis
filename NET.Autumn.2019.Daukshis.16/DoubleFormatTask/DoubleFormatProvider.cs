using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace DoubleFormatTask
{
    /// <summary>
    /// DoubleFormatProvider.
    /// </summary>
    /// <seealso cref="System.IFormatProvider" />
    /// <seealso cref="System.ICustomFormatter" />
    public class DoubleFormatProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider _parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleFormatProvider"/> class.
        /// </summary>
        public DoubleFormatProvider() : this(CultureInfo.InvariantCulture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleFormatProvider"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public DoubleFormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType">formatType</paramref>, if the <see cref="System.IFormatProvider"></see> implementation can supply that type of object; otherwise, null.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>
        /// The string representation of the value of <paramref name="arg">arg</paramref>, formatted as specified by <paramref name="format">format</paramref> and <paramref name="formatProvider">formatProvider</paramref>.
        /// </returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is null || format != "NUM" || !(arg is double))
                return string.Format(_parent, "{0}", arg);

            return TransformToString((double)arg);
        }
        
        private string TransformToString(double doubleNumber)
        {
            Number num = new Number(doubleNumber);
            long value = num.longValue;
            StringBuilder builder = new StringBuilder(64);
            for (int i = 63; i >= 0; i--)
            {
                string digit = ((value & (1 << 63)) >> 63).ToString() == "0" ? "0" : "1";
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