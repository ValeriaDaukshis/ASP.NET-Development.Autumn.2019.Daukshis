using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PseudoEnumerable.Tests
{
    [TestFixture]
    public class EnumerableExtensionTests
    {
        private IEnumerable<int> _enumerableInt;
        private IEnumerable<string> _enumerableString;
        
        [SetUp]
        public void SetUp1()
        {
            _enumerableInt = new List<int>(new int[]{1, 3, 5, 7, 9});
            _enumerableString = new List<string>(new string[]{"1", "2", "3", "4","5"});
        }

        //OrderAccordingTo
        [Test]
        public void EnumerableExtension_TestOrderAccordingToWithDelegateComparer_ExpectSameArray()
        {
            var b = EnumerableExtension.OrderAccordingTo(_enumerableInt, (x, y) => x - y);
            var c = EnumerableExtension.OrderAccordingTo(_enumerableString, (x, y) => x.CompareTo(y));
            Assert.AreEqual(b, _enumerableInt);
            Assert.AreEqual(c, _enumerableString);
        }
        
        [Test]
        public void EnumerableExtension_TestOrderAccordingToWithDelegateComparer_ExpectReversedArray()
        {
            var b = EnumerableExtension.OrderAccordingTo(_enumerableInt, (x, y) => y - x);
            Assert.AreEqual(b, _enumerableInt.Reverse());
        }

        //Filter
        [Test]
        public void EnumerableExtension_TestFilterWithDelegateComparer_ExpectSameArray()
        {
            var b = EnumerableExtension.Filter(_enumerableInt, i => i % 2 == 0);
            var c = EnumerableExtension.Filter(_enumerableString, i => i.Length % 2 == 0);
            Assert.AreEqual(b, Array.Empty<int>());
            Assert.AreEqual(c, Array.Empty<string>());
        }
        
        //Transform
        [Test]
        public void EnumerableExtension_TestTransformWithDelegateConverter_ExpectArrayWithAllOneElements()
        {
            Converter<int, int> convert = i => i % 2;
            Converter<string, int> stringConverter = i => i.Length;
            var b = EnumerableExtension.Transform(_enumerableInt, convert);
            var c = EnumerableExtension.Transform(_enumerableString, stringConverter);
            Assert.AreEqual(b, new int[]{1, 1, 1, 1, 1});
            Assert.AreEqual(c, new int[]{1, 1, 1, 1, 1});
        }
        
        //Transform
        [Test]
        public void EnumerableExtension_TestTransformWithDelegateConverter_ExpectNewStringArray()
        {
            Converter<int, string> convert = i => (i % 2).ToString();
            Converter<string, string> stringConverter = i => i.Length.ToString();
            var b = EnumerableExtension.Transform(_enumerableInt, convert);
            var c = EnumerableExtension.Transform(_enumerableString, stringConverter);
            Assert.AreEqual(b, new string[]{"1", "1", "1", "1", "1"});
            Assert.AreEqual(c, new string[]{"1", "1", "1", "1", "1"});
        }
        
    }
}
