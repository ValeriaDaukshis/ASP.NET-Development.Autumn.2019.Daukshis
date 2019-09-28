
using NUnit.Framework;
using TransformerWithAbstractFactory;

namespace Transformer.Tests
{
    [TestFixture]
    public class TransformerTests
    {
        [TestCase(double.NaN, ExpectedResult = "Not a number")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "Negative infinity")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "Positive infinity")]
        [TestCase(-0.0d, ExpectedResult = "zero")]
        [TestCase(0.0d, ExpectedResult = "zero")]
        [TestCase(0.1d, ExpectedResult = "zero point one")]
        [TestCase(-23.809d, ExpectedResult = "minus two three point eight zero nine")]
        [TestCase(-0.123456789d, ExpectedResult = "minus zero point one two three four five six seven eight nine")]
        [TestCase(1.23333e308d, ExpectedResult = "one point two three three three three E plus three zero eight")]
        [TestCase(double.Epsilon, ExpectedResult = "four point nine four zero six five six four five eight four one two four seven E minus three two four")]
        public string TransformerWithAbstractFactory_ReturnsArrayOfStringsWithWordsOfDigits(double number)
        {
            TransformerWithAbstractFactory.Transformer a =  new TransformerWithAbstractFactory.Transformer(new TransformToEnglish());
            return a.Transform(number);
        }
        
        [TestCase(double.NaN, ExpectedResult = "Not a number")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "Negative infinity")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "Positive infinity")]
        [TestCase(-0.0d, ExpectedResult = "zero")]
        [TestCase(0.0d, ExpectedResult = "zero")]
        [TestCase(0.1d, ExpectedResult = "zero point one")]
        [TestCase(-23.809d, ExpectedResult = "minus two three point eight zero nine")]
        [TestCase(-0.123456789d, ExpectedResult = "minus zero point one two three four five six seven eight nine")]
        [TestCase(1.23333e308d, ExpectedResult = "one point two three three three three E plus three zero eight")]
        [TestCase(double.Epsilon, ExpectedResult = "four point nine four zero six five six four five eight four one two four seven E minus three two four")]
        public string ArrayToTextArray_ReturnsArrayOfStringsWithWordsOfDigits(double number)
            => new Transform().TransformToWords(number); 
    }
}
