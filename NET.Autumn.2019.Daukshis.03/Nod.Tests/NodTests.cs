using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int FindNextBiggerNumber_2Numbers_NodExpected(int number1, int number2)
            => NODClass.Nod.EvklidMethod(number1, number2);

        [TestCase(111111111, 0, 0, ExpectedResult = 111111111)]
        [TestCase(0, 0, 0, ExpectedResult = 0)] 
        [TestCase(7, 7, 7, ExpectedResult = 7)] 
        [TestCase(1071, 147, 462, ExpectedResult = 21)]
        [TestCase(1071, 148, 462, ExpectedResult = 1)]
        [TestCase(25, -5, -10,  ExpectedResult = 5)] 
        public int FindNextBiggerNumber_3Numbers_NodExpected(int number1, int number2, int number3)
            => NODClass.Nod.EvklidMethod(number1, number2, number3);

        [TestCase(new int[]{ 1071, 147, 462, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 25, 125, -75, 500, -375}, ExpectedResult = 25)]
        [TestCase(new int[] { 25, 125, -75, 500, -375, 0, 0}, ExpectedResult = 25)] 
        public int FindNextBiggerNumber_ArrayOfNumbers_NodExpected(int[] array)
            => NODClass.Nod.EvklidMethod(array);
    }
}
