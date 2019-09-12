using System;

namespace FindNthRootClass
{
    public static class Root
    {
        /// <summary>
        /// FindNthRoot
        /// </summary>
        /// <param name="number">initial number</param>
        /// <param name="root">root from number</param>
        /// <param name="accuracy">accuracy</param>
        /// <returns>
        /// n-power root from number with accuracy accuracy
        /// </returns>
        public static double FindNthRoot(double number, int root, double accuracy)
        {
            CheckInput(number, root, accuracy);

            double x0 = number / root;
            double x1 = 1 / (double)root * ((root - 1) * x0 + number / Pow(x0, root - 1));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = 1 / (double)root * ((root - 1) * x0 + number / Pow(x0, root - 1));
            }
            
            double result = (int) (x1 / accuracy) * accuracy;
            int eps = 0;
            while (accuracy != 1)
            {
                accuracy *= 10;
                eps++;
            }
            return Math.Round(result, eps);
        }

        /// <summary>
        /// Number power
        /// </summary>
        /// <param name="number">initial number</param>
        /// <param name="pow">power</param>
        /// <returns>number in pow degree</returns>
        private static double Pow(double number, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
                result *= number;
            return result;
        }

        /// <summary>
        /// Check input data
        /// </summary>
        /// <param name="number">initial number</param>
        /// <param name="root">root from number</param>
        /// <param name="accuracy">accuracy</param>
        private static void CheckInput(double number, int root, double accuracy)
        {
            if (number < 0 & root % 2 == 0)
                throw new ArgumentException("Incorrect root");
            if (root < 0)
                throw new ArgumentException("Root must be positive");
            if (accuracy > 1 | accuracy < 0)
                throw new ArgumentException("Incorrect accuracy");
        }
    }
}
