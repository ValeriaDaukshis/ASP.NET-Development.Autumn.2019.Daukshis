using NUnit.Framework;

namespace Generator.Tests
{
    public class GeneratorTests
    {
        [TestCase(10, 4, 7)] //new ulong[]{2,3,5,7})
        [TestCase(30, 10, 29)] //new ulong[]{2,3,5,7,11,13,17,19,23,29}
        [TestCase(100_000_000, 5761455, 99999989)]
        public void Generate_SimpleValuesArrayExpected(int limit, int count, int lastValue)
        {
            int i = 0;
            int number = 0;
            foreach (var value in Task1.Generator.GenerateSimpleNumbers(limit))
            {
                ++i;
                number = value;
            }
            
            Assert.AreEqual(i, count);
            Assert.AreEqual(lastValue, number);
        }
    }
}