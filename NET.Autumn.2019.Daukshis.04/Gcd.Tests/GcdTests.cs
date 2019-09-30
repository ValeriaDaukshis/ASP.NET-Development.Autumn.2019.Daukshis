
using FindGcd;
using NUnit.Framework;

namespace Gcd.Tests
{
    [TestFixture]
    public class GcdTests
    {
        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641,569, ExpectedResult = 569)]
        public int FindGcdByEuclidean_2Numbers_GcdExpected(int number1, int number2)
            => FindGcd.Gcd.FindGcdByEuclidean(number1, number2); 

        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int FindGcdByEuclidean_3Numbers_GcdExpected(int number1, int number2, int number3)
            => FindGcd.Gcd.FindGcdByEuclidean(number1, number2, number3);

        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
        [TestCase(new int[] { 25, 125, -75, 500, -375, 0, 0 }, ExpectedResult = 25)]
        public int FindGcdByEuclidean_ArrayOfNumbers_GcdExpected(int[] array)
            => FindGcd.Gcd.FindGcdByEuclidean(array);

        [TestCase(111111111, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(25, 5, ExpectedResult = 5)]
        [TestCase(25, -5, ExpectedResult = 5)]
        [TestCase(17, 5, ExpectedResult = 1)]
        [TestCase(-17, 5, ExpectedResult = 1)]
        [TestCase(50641, 569, ExpectedResult = 569)]
        public int FindGcdByStein_2Numbers_GcdExpected(int number1, int number2)
            => FindGcd.Gcd.FindGcdByStein(number1, number2);


        [TestCase(7, 7, 7, ExpectedResult = 7)]
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10, ExpectedResult = 5)]
        public int FindGcdByStein_3Numbers_GcdExpected(int number1, int number2, int number3)
            => FindGcd.Gcd.FindGcdByStein(number1, number2, number3);

        [TestCase(new int[] { 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375 }, ExpectedResult = 25)]
        [TestCase(new int[] { 20, 64, 358, 88 }, ExpectedResult = 2)]
        public int FindGcdByStein_GcdExpected(int[] array)
            => FindGcd.Gcd.FindGcdByStein(array);

        [Test]
        public void Tracer_FindGcdByStein_TimeOfMethodExpected()
        {
            Tracer tracer = new Tracer();
            tracer.StartTrace();
            FindGcd.Gcd.FindGcdByStein(new int[] {1071, 147, 462, 7});
            tracer.StopTrace();
            long actual = tracer.GetTraceResult();
            Assert.GreaterOrEqual(actual, 0);
        }
        
        [Test]
        public void Tracer_FindGcdByEuclidean_TimeOfMethodExpected()
        {
            ITracer tracer = new Tracer();
            tracer.StartTrace();
            FindGcd.Gcd.FindGcdByEuclidean(1071, 147, 462);
            tracer.StopTrace();
            long actual = tracer.GetTraceResult();
            Assert.GreaterOrEqual(actual, 0);
        }
    }
}