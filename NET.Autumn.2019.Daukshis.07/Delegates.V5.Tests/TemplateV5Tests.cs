using System;
using Algorithms.V5;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
    public class TemplateV5Tests
    {
        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641, 569, ExpectedResult = 569)]
        public int FindGcdByEuclidean_2Numbers(int number1, int number2)
            => GCDAlgorithms.GreatestCommonDivisor(number1, number2); 
        
        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int FindGcdByEuclidean_3Numbers(int number1, int number2, int number3)
            => GCDAlgorithms.GreatestCommonDivisor(number1, number2, number3);

        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
        [TestCase(new int[] { 25, 125, -75, 500, -375, 0, 0 }, ExpectedResult = 25)]
        public int FindGcdByEuclidean_ArrayOfNumbers(int[] array)
            => GCDAlgorithms.GreatestCommonDivisor(array);

        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641, 569, ExpectedResult = 569)]
        public int FindGcdByEuclidean_2NumbersWithTimer(int number1, int number2)
        {
            int result = GCDAlgorithms.GreatestCommonDivisor(out long milliseconds, number1, number2);
            Assert.GreaterOrEqual(milliseconds, 0);
            return result;
        }
        
        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int FindGcdByEuclidean_3NumbersWithTimer(int number1, int number2, int number3)
        {
            int result = GCDAlgorithms.GreatestCommonDivisor(out long milliseconds, number1, number2, number3);
            Assert.GreaterOrEqual(milliseconds, 0);
            return result;
        }

        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
        [TestCase(new int[] { 25, 125, -75, 500, -375, 0, 0 }, ExpectedResult = 25)]
        public int FindGcdByEuclidean_ArrayOfNumbersWithTimer(int[] array)
        {
            int result = GCDAlgorithms.GreatestCommonDivisor(out long milliseconds, array);
            Assert.GreaterOrEqual(milliseconds, 0);
            return result;
        }
        
        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641,569, ExpectedResult = 569)]
        public int FindGcdByStain_2Numbers(int number1, int number2)
            => GCDAlgorithms.BinaryGreatestCommonDivisor(number1, number2); 
        
        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int FindGcdByStain_3Numbers(int number1, int number2, int number3)
            => GCDAlgorithms.BinaryGreatestCommonDivisor(number1, number2, number3);

        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
        [TestCase(new int[] { 25, 125, -75, 500, -375, 0, 0 }, ExpectedResult = 25)]
        public int FindGcdByStain_ArrayOfNumbers(int[] array)
            => GCDAlgorithms.BinaryGreatestCommonDivisor(array);

        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641, 569, ExpectedResult = 569)]
        public int FindGcdByStain_2NumbersWithTimer(int number1, int number2)
        {
            int result = GCDAlgorithms.BinaryGreatestCommonDivisor(out long milliseconds, number1, number2);
            Assert.GreaterOrEqual(milliseconds, 0);
            return result;
        }
        
        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int FindGcdByStain_3NumbersWithTimer(int number1, int number2, int number3)
        {
            int result = GCDAlgorithms.BinaryGreatestCommonDivisor(out long milliseconds, number1, number2, number3);
            Assert.GreaterOrEqual(milliseconds, 0);
            return result;
        }

        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
        [TestCase(new int[] { 25, 125, -75, 500, -375, 0, 0 }, ExpectedResult = 25)]
        public int FindGcdByStain_ArrayOfNumbersWithTimer(int[] array)
        {
            int result = GCDAlgorithms.BinaryGreatestCommonDivisor(out long milliseconds, array);
            Assert.GreaterOrEqual(milliseconds, 0);
            return result;
        }

        [Test]
        public void FindGCDByStain_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException), delegate 
                { GCDAlgorithms.BinaryGreatestCommonDivisor(new int[] {0, 0, 0, 0, 0}); });
        }
        
        [Test]
        public void FindGCDByEuclidean_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException), () =>  
                { GCDAlgorithms.GreatestCommonDivisor(0, 0); });
        }
    }
}