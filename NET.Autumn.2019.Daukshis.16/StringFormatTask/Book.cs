using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StringFormatTask
{
    /// <summary>
    /// Book.
    /// </summary>
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public string PublishingHous { get; private set; }
        public int Edition { get; private set; }
        public int Pages { get; private set; }
        public int Price { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="author">The author.</param>
        /// <param name="year">The year.</param>
        /// <param name="publishingHous">The publishing hous.</param>
        /// <param name="edition">The edition.</param>
        /// <param name="pages">The pages.</param>
        /// <param name="price">The price.</param>
        public Book(string title, string author, int year, string publishingHous, int edition, int pages, int price)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.PublishingHous = publishingHous;
            this.Edition = edition;
            this.Pages = pages;
            this.Price = price;
        }
    }
    
    /// <summary>
    /// BookFormatProvider.
    /// </summary>
    public class BookFormatProviders : IFormatProvider, ICustomFormatter
    {
        IFormatProvider _parent;

        private Dictionary<string, Func<Book, string>> availableFormats = new Dictionary<string, Func<Book, string>>();
        private static CultureInfo culture = CultureInfo.InvariantCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatProvider"/> class.
        /// </summary>
        public BookFormatProviders() : this(CultureInfo.InvariantCulture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookFormatProvider"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public BookFormatProviders(IFormatProvider parent)
        {
            _parent = parent;
            InitializeDictionary();
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
            if (arg is null || !availableFormats.ContainsKey(format) || !(arg is Book))
                return string.Format(_parent, "{0}", arg);

            return availableFormats[format].Invoke(arg as Book);
        }

        private void InitializeDictionary()
        {
            availableFormats.Add("N", NameFormat);
            availableFormats.Add("A", AuthorFormat);
            availableFormats.Add("Y", YearFormat);
            availableFormats.Add("P", PriceFormat);
            availableFormats.Add("Ph", PublishingHousFormat);
            availableFormats.Add("NA", NameAuthorFormat);
            availableFormats.Add("NAY", NameAuthorYearFormat);
            availableFormats.Add("NAP", NameAuthorPriceFormat);
        }
        
        private static readonly Func<Book, string> NameFormat = (obj) => obj.Title;
        private static readonly Func<Book, string> AuthorFormat = (obj) => obj.Author;
        private static readonly Func<Book, string> YearFormat = (obj) => obj.Year.ToString(culture);
        private static readonly Func<Book, string> PriceFormat = (obj) => obj.Price.ToString(culture);
        private static readonly Func<Book, string> PublishingHousFormat = (obj) => obj.PublishingHous;

        private static readonly Func<Book, string> NameAuthorFormat = (obj) =>
        {
            StringBuilder builder = new StringBuilder(3);
            builder.Append(NameFormat.Invoke(obj));
            builder.Append(", ");
            builder.Append(AuthorFormat.Invoke(obj));
            return builder.ToString();
        };

        private static readonly Func<Book, string> NameAuthorYearFormat = (obj) =>
        {
            StringBuilder builder = new StringBuilder(3);
            builder.Append(NameAuthorFormat.Invoke(obj));
            builder.Append(", ");
            builder.Append(YearFormat.Invoke(obj));
            return builder.ToString();
        };

        private static readonly Func<Book, string> NameAuthorPriceFormat = (obj) =>
        {
            StringBuilder builder = new StringBuilder(3);
            builder.Append(NameAuthorFormat.Invoke(obj));
            builder.Append(", ");
            builder.Append(PriceFormat.Invoke(obj));
            return builder.ToString();
        };
    }
}