using System;
using System.Linq;
using System.Text;

namespace Task1
{
    public class CompareBySymbol : ICompare
    {
        private readonly int  _toBase;
        private readonly char _symbol;

        public CompareBySymbol(int toBase, char symbol)
        {
            _toBase = toBase;
            _symbol = symbol;
        }

        public int CompareNumbers(int number1, int number2)
        {
            string convertedNumber1 = ConvertToBase(number1, _toBase);
            string convertedNumber2 = ConvertToBase(number2, _toBase);

            int counter1 = 0;
            for (int i = 0; i < convertedNumber1.Length; i++)
                if (convertedNumber1[i] == _symbol)
                    counter1++;

            int counter2 = 0;
            for (int i = 0; i < convertedNumber2.Length; i++)
                if (convertedNumber2[i] == _symbol)
                    counter2++;

            return counter1.CompareTo(counter2);
        }

        private string ConvertToBase(int number, int toBase)
        {
            StringBuilder convertedNumber = new StringBuilder();
            while (number >= 1)
            {
                convertedNumber.Insert(0,(number % toBase).ToString());
                number /= toBase;
            }

            return convertedNumber.ToString(); 
        }

    }
}
