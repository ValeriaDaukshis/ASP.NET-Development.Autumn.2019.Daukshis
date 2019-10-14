using Algorithms.V3.GcdImplementations;
using NUnit.Framework;

namespace Decorator.V3.Tests
{
    [TestFixture]
    public class DecoratorTests
    {
        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641,569, ExpectedResult = 569)]
        public int FindGcdByEuclidean_2Numbers(int number1, int number2)
            => new EuclideanAlgorithmDecorator(new EuclideanAlgorithm()).Calculate(number1, number2); 
        
        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int FindGcdByEuclidean_3Numbers(int number1, int number2, int number3)
        {
            int result = new EuclideanAlgorithmDecorator(new EuclideanAlgorithm()).Calculate(number1, number2);
            return new EuclideanAlgorithmDecorator(new EuclideanAlgorithm()).Calculate(result, number3);
        }

//        [TestCase(new int[] {1071, 147, 462, 7}, ExpectedResult = 7)]
//        [TestCase(new int[] {25, 125, -75, 500, -375}, ExpectedResult = 25)]
//        [TestCase(new int[] {25, 125, -75, 500, -375, 0, 0}, ExpectedResult = 25)]
//        public int FindGcdByEuclidean_ArrayOfNumbers(int[] array)
//        {
//            int result = array[0];
//            for(int i = 1 ; i < array.Length; i++)
//                result = new EuclideanAlgorithmDecorator(new EuclideanAlgorithm()).Calculate(result, number3);
//            return result;
//        }
//
//        [TestCase(111111111, 0, ExpectedResult = 111111111)]
//        [TestCase(0, 0, ExpectedResult = 0)]
//        [TestCase(1, 1, ExpectedResult = 1)]
//        [TestCase(25, 5, ExpectedResult = 5)]
//        [TestCase(25, -5, ExpectedResult = 5)]
//        [TestCase(17, 5, ExpectedResult = 1)]
//        [TestCase(-17, 5, ExpectedResult = 1)]
//        [TestCase(50641, 569, ExpectedResult = 569)]
//        public int FindGcdByEuclidean_2NumbersWithTimer(int number1, int number2)
//        {
//            EuclideanAlgorithmDecorator decorator = new EuclideanAlgorithmDecorator(new EuclideanAlgorithm());
//            int result = decorator.Calculate(number1, number2);
//            Assert.GreaterOrEqual(decorator.Milliseconds, 0);
//            return result;
//        }
//        
//        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
//        [TestCase(0, 0, 0, ExpectedResult = 0)]
//        [TestCase(7, 7, 7, ExpectedResult = 7)]
//        [TestCase(1071, 147, 462, ExpectedResult = 21)]
//        [TestCase(1071, 148, 462, ExpectedResult = 1)]
//        [TestCase(25, -5, -10, ExpectedResult = 5)]
//        public int FindGcdByEuclidean_3NumbersWithTimer(int number1, int number2, int number3)
//        {
//            int result = GCDAlgorithms.FindGcdByEuclidean(out long milliseconds, number1, number2, number3);
//            Assert.GreaterOrEqual(milliseconds, 0);
//            return result;
//        }
//
//        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
//        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
//        [TestCase(new int[] { 25, 125, -75, 500, -375, 0, 0 }, ExpectedResult = 25)]
//        public int FindGcdByEuclidean_ArrayOfNumbersWithTimer(int[] array)
//        {
//            int result = GCDAlgorithms.FindGcdByEuclidean(out long milliseconds, array);
//            Assert.GreaterOrEqual(milliseconds, 0);
//            return result;
//        }
    }
}