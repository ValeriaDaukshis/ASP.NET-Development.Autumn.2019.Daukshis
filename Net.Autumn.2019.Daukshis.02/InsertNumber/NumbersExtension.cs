using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNumber
{
    public static class NumbersExtension
    {
        public static int InsertNumberIntoAnother(int initialNum, int insertedNum, int i, int j)
        {
            CheckInput(initialNum, insertedNum, i, j);
            int insertedNumLength = j - i + 1;
            int insertedNumWithMask = 0; 

            for (int k = 0; k < insertedNumLength; k++)
            {
                int a = (insertedNum & 1) << k;
                insertedNumWithMask = insertedNumWithMask | a;
                insertedNum >>= 1;
            }

            insertedNumWithMask <<= i; 
           
            for (int k = i; k <= j; k++) 
                initialNum = initialNum & (~(1 << k));  
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
