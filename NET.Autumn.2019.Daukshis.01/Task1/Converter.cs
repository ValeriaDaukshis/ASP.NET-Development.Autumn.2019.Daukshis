
using System.Text;

namespace Task1
{
    public static class Converter
    {
        /// <summary>
        /// Converts to base.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="toBase">To base.</param>
        /// <returns>Converted number</returns>
        public static string ConvertToBase(int number, int toBase)
        {
            StringBuilder convertedNumber = new StringBuilder();
            if (number == 0)
                return "0";

            while (number >= 1)
            {
                int result = number % toBase;
                string convertedSymbol  = result < 10 ? result.ToString() : (result + 'A' - 10).ToString() ; 
                convertedNumber.Insert(0, convertedSymbol);
                number /= toBase;
            }

            if (number < 0)
                convertedNumber.Insert(0, "-");

            return convertedNumber.ToString();
        }

    }
}
