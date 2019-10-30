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

        /// <summary>
        /// Converts to stringfullobject.
        /// </summary>
        /// <returns></returns>
        public string ToStringFullObject()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Book record: ");
            builder.Append(Title + ", ");
            builder.Append(Author + ", ");
            builder.Append(Year + ", ");
            builder.Append(PublishingHous + ", ");
            builder.Append(Edition + ", ");
            builder.Append(Pages + ", ");
            builder.Append(Price);

            return builder.ToString();
        }

        /// <summary>
        /// Converts to stringv1.
        /// </summary>
        /// <returns></returns>
        public string ToStringV1()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Book record: ");
            builder.Append(Title + ", ");
            builder.Append(Author + ", ");
            builder.Append(PublishingHous);

            return builder.ToString();
        }

        /// <summary>
        /// Converts to stringv2.
        /// </summary>
        /// <returns></returns>
        public string ToStringV2()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Book record: ");
            builder.Append(Title + ", ");
            builder.Append(Author + ", ");
            builder.Append(Year + ", ");
            builder.Append(PublishingHous + ", ");
            builder.Append(Edition + ", ");

            return builder.ToString();
        }

        /// <summary>
        /// Converts to stringv3.
        /// </summary>
        /// <returns></returns>
        public string ToStringV3()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Book record: ");
            builder.Append(Title + ", ");
            builder.Append(Author);

            return builder.ToString();
        }
    }
}