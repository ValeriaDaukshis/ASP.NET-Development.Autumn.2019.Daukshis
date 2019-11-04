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
}