using NUnit.Framework;
using GcdClass;

namespace Nod.Tests
{
    [TestFixture]
    public class NodTests
    {
        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641,569, ExpectedResult = 569)]
        public int EvklidMethod_2Numbers_GcdExpected(int number1, int number2)
            => new Gcd().EvklidMethod(number1, number2); 

        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int EvklidMethod_3Numbers_GcdExpected(int number1, int number2, int number3)
            => new Gcd().EvklidMethod(number1, number2, number3);

        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
        [TestCase(new int[] { 25, 125, -75, 500, -375, 0, 0 }, ExpectedResult = 25)]
        public int EvklidMethod_ArrayOfNumbers_GcdExpected(int[] array)
            => new Gcd().EvklidMethod(array);

        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641, 569, ExpectedResult = 569)]
        public int BinaryMethod_2Numbers_GcdExpected(int number1, int number2)
            => new Gcd().BinaryMethod(number1, number2);


        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int BinaryMethod_3Numbers_GcdExpected(int number1, int number2, int number3)
            => new Gcd().BinaryMethod(number1, number2, number3);

        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
        [TestCase(new int[] { 20, 64, 358, 88 }, ExpectedResult = 2)]
        public int BinaryMethod_ArrayOfNumbers_GcdExpected(int[] array)
            => new Gcd().BinaryMethod(array);

        [Test]
        public void Timer_EvklidMethod2Numbers_TimeOfMethodExpected()
        {
            long sd = Gcd.Timer("EvklidMethod", 5, 2);
            Assert.GreaterOrEqual(sd, 0);
        }

        [Test]
        public void Timer_EvklidMethod3Numbers_TimeOfMethodExpected()
        {
            long sd = Gcd.Timer("EvklidMethod", 5, 2, 25);
            Assert.GreaterOrEqual(sd, 0);
        }

    }
}
