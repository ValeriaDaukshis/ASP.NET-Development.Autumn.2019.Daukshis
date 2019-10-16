using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public static class StringExtensions
    {
        /// <summary>
        /// GetWords
        /// </summary>
        /// <param name="text">init string</param>
        /// <returns>array of uniq words</returns>
        public static string[] GetWords(string text, char[] punctuation)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException();
            
            string[] words = text.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> uniqWordsSet = new HashSet<string>(words, StringComparer.InvariantCultureIgnoreCase);
            
            return uniqWordsSet.ToArray();
        }
    }
}
