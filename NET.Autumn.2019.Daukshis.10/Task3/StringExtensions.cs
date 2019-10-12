using System;
using System.Collections.Generic;

namespace Task3
{
    public static class StringExtensions
    {
        public static string[] GetWords(string text)
        {
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
