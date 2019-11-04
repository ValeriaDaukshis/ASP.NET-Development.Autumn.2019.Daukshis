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
        /// <param name="parent">The parent.</param>
        public BookFormatProvider(IFormatProvider parent)
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
    }
}