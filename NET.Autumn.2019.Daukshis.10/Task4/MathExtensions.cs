using System;
using System.Collections.Generic;

namespace Task4
{
    public static class MathExtensions
    {
        /// <summary>
        /// Circle
        /// </summary>
        /// <param name="array">init array</param>
        /// <param name="step">step</param>
        /// <returns></returns>
        public static T Circle<T>(LinkedList<T> numbers, int step)
        {
            if(step <= 0)
            {
                throw new ArgumentException($"nameof{step} is less than zero");
            }
            if(numbers == null)
            {
                throw new ArgumentNullException();
            }
            if(numbers.Count == 0)
            {
                throw new ArgumentException();
            }
            if (numbers.Count == 1)
            {
                return numbers.First.Value;
            }
            
            LinkedListNode<T> current = numbers.First;
            LinkedListNode<T> last = numbers.Last;
            LinkedListNode<T> first = current;
            do{
                for (int i = 0; i < step; i++)
                {
                    if (current == last)
                    {
                        current = first;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }

                LinkedListNode<T> removedElement = current;
                if (current == first)
                {
                    first = current.Next;
                    current = last; 
                }
                else if (current == last)
                {
                    last = current.Previous;
                    current = last;
                }
                else
                    current = current.Previous;
                
                numbers.Remove(removedElement);
            }
            while (numbers.Count > 1) ;

            return current.Value;
        }
    }
}