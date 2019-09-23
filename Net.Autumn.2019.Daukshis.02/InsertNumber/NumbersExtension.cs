// Идея
// 1. наложить маску на число, которое вставляешь
// 2. предварительно занулить разряды в исходном числе
// 3. сделать or | с полученными значениями


using System;

namespace InsertNumber
{
    public static class NumbersExtension
    {
        public static int InsertNumberIntoAnother(int initialNum, int insertedNum, int i, int j)
        {
            CheckInput(initialNum, insertedNum, i, j);
            int insertedNumLength = j - i + 1;
            int insertedNumWithMask = 0; 

			// 1 пункт
			// способ отличается от того, что рассказывал чел
			// исходное число : 010111, нам нужно выделить младшие 4 разряда(например)
			// должно получиться: 0111
			// 1) a = 1 ; insertedNumWithMask = 1; insertedNum = 01011
			// 2) a = 10 ; insertedNumWithMask = 11; insertedNum = 0101
			// 3) a = 100 ; insertedNumWithMask = 111; insertedNum = 010
			// 4) a = 1000; insertedNumWithMask = 0111; insertedNum = 01
            for (int k = 0; k < insertedNumLength; k++)
            {
                int a = (insertedNum & 1) << k;
                insertedNumWithMask = insertedNumWithMask | a;
                insertedNum >>= 1;
            }
			// сдвиг на нужное количество разрядов
            insertedNumWithMask <<= i; 
           
		    // 2 пункт
		    // обгуляем поразрядно
			// чекаем с i по j
			// пример число 01 1101 010   i = 3 j = 6
			// 1) (1 << k) = 1000; ~(1 << k) = 0111; число : 01 1100 010
			// 2) (1 << k) = 10000; ~(1 << k) = 01111; число : 01 1100 010
			// 3) (1 << k) = 100000; ~(1 << k) = 011111; число : 01 1000 010
			// 4) (1 << k) = 1000000; ~(1 << k) = 0111111; число : 01 0000 010
			
            for (int k = i; k <= j; k++) 
                initialNum = initialNum & (~(1 << k));  

			// 3 пункт
            return insertedNumWithMask | initialNum;
        }

        private static void CheckInput(int number1, int number2, int i, int j)
        {
            if (i > j)
                throw new ArgumentException("Incorrect index i or j");
            if (i < 0)
                throw new ArgumentOutOfRangeException("Index i is less than 0"); 
            if(i >= 32 || j >= 32)
                throw new ArgumentOutOfRangeException("Index is greater than 32"); 
        }
    }
}
