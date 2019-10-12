using System;
using System.Collections.Generic;

namespace Task3
{
    public static class StringExtensions
    {
        /// <summary>
        /// GetWords
        /// </summary>
        /// <param name="text">init string</param>
        /// <returns>array of uniq words</returns>
        public static string[] GetWords(string text)
        {
            if(string.IsNullOrEmpty(text))
                throw new ArgumentException();
            
            HashSet<string> uniqWordsSet = new HashSet<string>();
            char[] punctuation = {' ', ',', '!', '.', '-', ';', ':', '—', '-' };
            string[] words = text.Split(punctuation);
            List<string> uniqWords = new List<string>(words.Length);
            
            for (int i = 0 ; i < words.Length; i++)
            {
                if (words[i].Trim() != "" && uniqWordsSet.Add(words[i].ToLower()))
                {
                    uniqWords.Add(words[i]); 
                }
            }
            return uniqWords.ToArray();
        }
    }
}
