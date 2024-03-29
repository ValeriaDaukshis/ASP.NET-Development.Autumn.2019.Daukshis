using System;
using Filter.Dictionaries;
using Filter.Filters;
using Filter.StaticArrayExtensions;
using Filter.Transformers;
using NUnit.Framework;

namespace Filter.Tests.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {  
        //FIND MAX VALUE
        
        [TestCase(new int[] { 0, 15, 32, 125, -10, 64, 29 }, ExpectedResult = 125)]
        [TestCase(new int[] { -100, -20, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] {145, -89, 145, 145, 33}, ExpectedResult = 145)]
        [TestCase(new int[] {-1}, ExpectedResult = -1)]
        public int FindMaximumItem_Array_MaxNumberInInt32Array(int[] actual)
            => actual.FindMaximumItem();
        
        
        [Test]
        public void FindMaximumItem_BigLengthArray_MaxNumberExpected()
        {
            int[] array = new int[100_000_000];
            Random rand = new Random();
            for (int i = 0; i < 100_000_000; i++) 
                array[i] = rand.Next(0, 10000);  

            array[rand.Next(100, 100_000_000)] = 1010101; 
            int actual = array.FindMaximumItem();
            int expected = 1010101;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMaximumItem_ZeroLengthArray_ArgumentException()
        {
            Assert.Throws(typeof(IndexOutOfRangeException),
                () => new int[] { }.FindMaximumItem());
        }
        
        // FILTER
        
        [TestCase(new[] { 121, 1405644, -1036674 }, '2', ExpectedResult = new[] { 121 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, '2', ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, '7', ExpectedResult =
            new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, '9', ExpectedResult = new int[0])]
        public int[] FilterArrayByKey_ArrayAndValue_FilteredArrayExpected(int[] array, char value)
            => array.Filter(new FilterByKey<int>(value));
        

        [Test]
        public void FilterArrayByKey_NullArray_ArgumentNullException()
        {
            int[] a = null;
            Assert.Throws(typeof(ArgumentNullException),
                () => a.Filter<int>(new FilterByKey<int>('5')));
        }
        
        //TRANSFORMERS
        
        [TestCase(new double[]{double.NaN, double.NegativeInfinity, -0.0d, 0.1d, -23.809d, double.Epsilon}, 
            ExpectedResult = new string[]
            {
                "Not a number", "Negative infinity", "zero", "zero point one",
                "minus two three point eight zero nine",
                "four point nine four zero six five six four five eight four one two four seven E minus three two four"
            })]
        public string[] EnglishTransformer_ReturnsArrayOfStringsWithWordsOfDigits(double[] number)
             => number.Transform( new DictionaryTransformer(new EnglishDictionary()));
        
        
        [TestCase(new double[]{double.NaN, double.NegativeInfinity, -0.0d, 0.1d, -23.809d}, 
             ExpectedResult = new string[]
             {
                 "Не число", "Отрицательная бесконечность", "ноль", "ноль точка один",
                 "минус два три точка восемь ноль девять"
             })] 
        public string[] RussianTransformer_ReturnsArrayOfStringsWithWordsOfDigits(double[] number)
             =>  number.Transform<double, string>(new DictionaryTransformer(new RussianDictionary()));
         
        
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
            => value.Transform(new TransformerTo2Notation());

         //SORTINGS
        [TestCase(new string[]{"25", "46", "16"}, new string[]{"16", "25", "46"})]
        [TestCase(new string[]{"3", "4", "5"}, new string[] { "3", "4", "5"})]
        [TestCase(new string[]{null, "a", "B", "b"}, new string[] {null, "a", "b", "B"})]
        public void OrderAccordingTo_SortArrayByLetters(string[] actual, string[] expected)
        {
            actual.OrderAccordingTo();
            Assert.AreEqual(expected, actual); 
        }
        
        
        //TYPED ARRAY
        [TestCase(new object[]{"25adsa",125, 36.5, "46sd", "16ahg"},typeof(string), new string[]{ "25adsa", "46sd", "16ahg"})]
        [TestCase(new object[]{'3',12, '4', '5', "fd"}, typeof(string), new string[] { "fd"})]
        [TestCase(new object[]{"A", "a", "Ba", "b"}, typeof(string), new string[] {"A", "a", "Ba", "b"})]
        //[TestCase(new object[]{null, "a", "B", "b"}, typeof(string),new string[] { "a", "B", "b", null})]
        public void TypedArray_GetStringArray(object[] array,Type type, string[] expected)
        {
            string[] actual = array.TypedArray<object, string>();
            Assert.AreEqual(expected, actual); 
        }


        [TestCase(new object[]{'3',12, '4', '5', "fd"}, typeof(char), new char[] { '3', '4', '5'})]
        public void TypedArray_GetCharArray(object[] array,Type type, char[] expected)
        {
            char[] actual = array.TypedArray<object, char>();
            Assert.AreEqual(expected, actual); 
        }


        [TestCase(new object[]{"A", 1, 25, 36.5,"a", "Ba",16, "b"}, typeof(int), new int[] {1, 25, 16})]
        public void TypedArray_GetInt32Array(object[] array,Type type, int[] expected)
        {
            int[] actual = array.TypedArray<object, int>();
            Assert.AreEqual(expected, actual); 
        }

        [TestCase(new object[]{"25adsa",125, 36.5, "46sd", "16ahg"},typeof(double), new double[]{ 36.5})]
        public void TypedArray_GetDoubleArray(object[] array,Type type, double[] expected)
        {
            double[] actual = array.TypedArray<object, double>();
            Assert.AreEqual(expected, actual); 

        }

    }
}