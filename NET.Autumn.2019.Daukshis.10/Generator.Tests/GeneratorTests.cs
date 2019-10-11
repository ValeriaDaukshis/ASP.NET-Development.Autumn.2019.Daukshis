using NUnit.Framework;

namespace Generator.Tests
{
    public class GeneratorTests
    {
        [TestCase((ulong)10, (ulong)4, (ulong)7)] //new ulong[]{2,3,5,7})
        [TestCase((ulong)30, (ulong)10, (ulong)29 )] //new ulong[]{2,3,5,7,11,13,17,19,23,29}
        [TestCase((ulong)100_000_000, (ulong)5761455, (ulong)99999989 )]
        public void Generate_SimpleValuesArrayExpected(ulong limit, ulong count, ulong lastValue)
        {
            ulong i = 0;
            ulong number = 0;
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