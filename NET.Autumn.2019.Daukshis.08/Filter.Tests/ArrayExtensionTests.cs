using System;
using Filter.Dictionaries;
using Filter.Filters;
using Filter.StaticArrayExtensions;
using Filter.Transformers;
using NUnit.Framework;

namespace Filter.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {  
        //FIND MAX VALUE
        
        [TestCase(new int[] { 0, 15, 32, 125, -10, 64, 29 }, ExpectedResult = 125)]
        [TestCase(new int[] { -100, -20, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] {145, -89, 145, 145, 33}, ExpectedResult = 145)]
        [TestCase(new int[] {-1}, ExpectedResult = -1)]
        public int FindMaximumItem_Array_MaxNumberInArray(int[] actual)
            => ArrayExtension.FindMaximumItem(actual);

        [Test]
        public void FindMaximumItem_BigLengthArray_MaxNumberExpected()
        {
            int[] array = new int[100_000_000];
            Random rand = new Random();
            for (int i = 0; i < 100_000_000; i++) 
                array[i] = rand.Next(0, 10000);  

            array[rand.Next(100, 100_000_000)] = 1010101; 
            int actual = ArrayExtension.FindMaximumItem(array);
            int expected = 1010101;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMaximumItem_ZeroLengthArray_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException),
                () => ArrayExtension.FindMaximumItem(new int[] { }));
        }

        [Test]
        public void FindMaximumItem_ZeroLengthArray_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => ArrayExtension.FindMaximumItem(null));
        }
        
        // FILTER
        
        [TestCase(new[] { 121, 1405644, -1036674 }, 2, ExpectedResult = new[] { 121 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult =
            new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        public int[] FilterArrayByKey_ArrayAndValue_FilteredArrayExpected(int[] array, int value)
            => ArrayExtension.Filter(array, new FilterByKey(value));

        [Test]
        public void FilterArrayByKey_NullArray_ArgumentNullException()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => ArrayExtension.Filter(null, new FilterByKey(55)));
        }

        [Test]
        public void FilterArrayByKey_ZeroLengthArray_ArgumentException()
        {
            Assert.Throws(typeof(ArgumentException),
                () => ArrayExtension.Filter(new int[] { }, new FilterByKey(55)));
        }
        
        [TestCase(new double[]{double.NaN, double.NegativeInfinity, -0.0d, 0.1d, -23.809d, double.Epsilon}, 
            ExpectedResult = new string[]
            {
                "Not a number", "Negative infinity", "zero", "zero point one",
                "minus two three point eight zero nine",
                "four point nine four zero six five six four five eight four one two four seven E minus three two four"
            })]
         public string[] EnglishTransformer_ReturnsArrayOfStringsWithWordsOfDigits(double[] number)
             => ArrayExtension.Transform(number, new DictionaryTransformer(new EnglishComplexDoubleValues(), new EnglishSimpleDoubleValues()));
        
        
         [TestCase(new double[]{double.NaN, double.NegativeInfinity, -0.0d, 0.1d, -23.809d}, 
             ExpectedResult = new string[]
             {
                 "Не число", "Отрицательная бесконечность", "ноль", "ноль точка один",
                 "минус два три точка восемь ноль девять"
             })] 
         public string[] RussianTransformer_ReturnsArrayOfStringsWithWordsOfDigits(double[] number)
             =>  ArrayExtension.Transform(number, new DictionaryTransformer(new RussianComplexDoubleValues(), new RussianSimpleDoubleValues()));
         
        
        [TestCase(new double[]{255.255, -255.255, double.MaxValue, double.NaN, double.PositiveInfinity, -0.0}, 
            ExpectedResult = new string[]
            {
                "0100000001101111111010000010100011110101110000101000111101011100",
                "1100000001101111111010000010100011110101110000101000111101011100",
                "0111111111101111111111111111111111111111111111111111111111111111",
                "1111111111111000000000000000000000000000000000000000000000000000",
                "0111111111110000000000000000000000000000000000000000000000000000",
                "1000000000000000000000000000000000000000000000000000000000000000"
            })]
        public string[] Converter_ReturnsDoubleValueInStringRepresentation(double[] value)
            => ArrayExtension.Transform(value, new TransformerTo2Notation());
        
    }
}