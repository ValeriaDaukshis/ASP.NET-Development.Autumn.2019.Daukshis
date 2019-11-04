using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StringFormatTask
{
    /// <summary>
    /// BookFormatProvider.
    /// </summary>
    public class BookFormatProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider _parent;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatProvider"/> class.
        /// </summary>
        public BookFormatProvider() : this(CultureInfo.InvariantCulture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatProvider"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public BookFormatProvider(IFormatProvider parent)
        {
            _parent = parent;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is null || (format != "NAYP") || !(arg is Book))
                return string.Format(_parent, "{0}", arg);

            Book obj = (Book)arg;
            StringBuilder builder = new StringBuilder(7);
            builder.Append(obj.Title);
            builder.Append(", ");
            builder.Append(obj.Author);
            builder.Append(", ");
            builder.Append(obj.Year);
            builder.Append(", ");
            builder.Append(obj.Price);
            
            return builder.ToString();
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }
    }
}