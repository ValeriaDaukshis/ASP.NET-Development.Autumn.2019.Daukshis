
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
        
        private static Stack<char> bracketsStack = new Stack<char>();
        
        /// <summary>
        /// CheckBrackets
        /// </summary>
        /// <param name="brackets">brackets string</param>
        /// <returns>true if brackets have correct positions</returns>
        public static bool CheckBrackets(string brackets)
        {
            if (brackets.Length % 2 != 0)
            {
                return false;
            }
            
            int i = -1;
            while (++i < brackets.Length - 1)
            {
                if (openBrackets.ContainsKey(brackets[i]))
                {
                    bracketsStack.Push(brackets[i]);
                    continue;
                } 
                if (closeBrackets.ContainsKey(brackets[i]))
                {
                    bracketsStack.TryPop(out char value);
                    if (closeBrackets[brackets[i]] != value)
                    {
                        return false;
                    }
                }
                
            }

            return true;
        }
    }
}