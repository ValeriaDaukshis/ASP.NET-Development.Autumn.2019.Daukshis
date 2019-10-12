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
        public static int Circle(int[] array, int step)
        {
            if(step <= 0)
            {
                throw new ArgumentException($"nameof{step} is less than zero");
            }
            if(array == null)
            {
                throw new ArgumentNullException();
            }
            if(array.Length == 0)
            {
                throw new ArgumentException();
            }
            if (array.Length == 1)
            {
                return array[0];
            }
            
            LinkedList<int> numbers = new LinkedList<int>(array);
            LinkedListNode<int> current = numbers.First;
            LinkedListNode<int> last = numbers.Last;
            LinkedListNode<int> first = current;
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

                LinkedListNode<int> removedElement = current;
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