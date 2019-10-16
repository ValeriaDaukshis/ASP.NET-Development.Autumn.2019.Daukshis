
using System.Collections.Generic;

namespace Task2
{
    public static class MathFunctions
    {
        private static Dictionary<char, char> openBrackets = new Dictionary<char, char>()
        {
            {'<', '>'},
            {'{', '}'},
            {'(', ')'},
            {'[', ']'}
        };
        
        private static Dictionary<char, char> closeBrackets = new Dictionary<char, char>()
        {
            {'>', '<'},
            {'}', '{'},
            {')' , '('},
            {']', '['}
        };

        /// <summary>
        /// CheckBrackets
        /// </summary>
        /// <param name="brackets">brackets string</param>
        /// <returns>true if brackets have correct positions</returns>
        public static bool CheckBrackets(string brackets)
        {
            Stack<char> bracketsStack = new Stack<char>();
         
            int i = -1;
            while (++i < brackets.Length)
            {
                if (openBrackets.ContainsKey(brackets[i]))
                {
                    bracketsStack.Push(brackets[i]);
                    continue;
                } 
                if (closeBrackets.ContainsKey(brackets[i]))
                {
                    char value = bracketsStack.Pop();
                    if (closeBrackets[brackets[i]] != value)
                    {
                        return false;
                    }
                }
            }

            if (bracketsStack.Count != 0)
                return false;
            return true;
        }
    }
}