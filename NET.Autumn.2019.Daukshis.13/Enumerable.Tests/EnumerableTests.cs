using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Enumerable.Tests
{
    public class EnumerableTests
    {
        private class People
        {
            private int population;
        }
        private class Student : People
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void SetUpList()
        {
            students = new List<Student>
            {
                new Student { Id = 1, Name = "Valerka" },
                new Student { Id = 2, Name = "Zhenya", },
                new Student { Id = 3, Name = "Kate" }
            };
        }

        private void SetUpArrayList()
        {
            list = new ArrayList
            {
                new Student { Id = 1, Name = "Valerka" },
                new Student { Id = 2, Name = "Zhenia", },
                new Student { Id = 3, Name = "Kate" }
            };
        }
        private List<Student> students;
        private ArrayList list;
        
        [Test]
        public void Enumerable_TestFilter()
        {
            IEnumerable<int> array = new[] { 12, 23, 16, 15 };
            int[] expected = { 12, 16 };
            int i = 0;
            foreach (var number in array.Filter(a => a % 2 == 0))
            {
                Assert.AreEqual(expected[i], number);
                i++;
            }
        }
        
        [Test]
        public void Enumerable_TestFilterWithClassStudents()
        {
            SetUpList();
            List<Student> expected = students;
            students.RemoveAt(0);
            int i = 0;
            foreach (var values in students.Filter(a => a.Id > 1 ))
            {
                Assert.AreEqual(expected[i], values);
                i++;
            }
        }
        
        [Test]
        public void Enumerable_TestTransform()
        {
            IEnumerable<int> array = new[] { 12, 23, 16, 15 };
            string[] expected = {"12", "23", "16", "15" };
            int i = 0;
            foreach (var number in array.Transform(a => a.ToString()))
            {
                Assert.AreEqual(expected[i], number);
                i++;
            }
        }
        
        [Test]
        public void Enumerable_TestCastTo()
        {
           SetUpArrayList();
            int i = 0;
            foreach (var number in list.CastTo<People>())
            {
                i++;
            }
            Assert.AreEqual(list.Count, i);
        }
        
        [Test]
        public void Enumerable_TestCastTo_ExpectedInvalidCastException()
        {
            SetUpArrayList();
            list.Add(5);
            Assert.Throws(typeof(InvalidCastException),() =>
            { 
                foreach (var number in list.CastTo<People>()){}
            });
        }
        
        [Test]
        public void Enumerable_TestRangeAndCount()
        {
            var iterator2 = EnumerableExtensions
                .Range(1, 20)
                .Filter(x => x % 2 == 0)
                .Transform(x => x * x)
                .Reverse()
                .Count();
            
            Assert.AreNotEqual(0, iterator2);
        }
        
        [Test]
        public void Enumerable_TestCountWithPredicate()
        {
            var iterator2 = EnumerableExtensions
                .Range(1, 20)
                .Filter(x => x % 2 == 0)
                .Transform(x => x * x)
                .Reverse()
                .Count(x => x.ToString().Length > 1);
            
            Assert.AreNotEqual(0, iterator2);
        }
        
        [Test]
        public void Enumerable_TestForAll()
        {
            IEnumerable<int> array = new[] { 12, 23, 16, 15 };
            bool actual = array.ForAll(x => x % 2 == 0);
            Assert.AreEqual(false, actual);
        }
        
        [Test]
        public void Enumerable_TestSortBy()
        {
            IEnumerable<string> array = new[] { "12", "0", "25", "135" };
            string[] expected = {"0", "12", "25", "135" };
            int i = 0;
            foreach (var number in array.SortBy(x => x.Length))
            {
                Assert.AreEqual(number, expected[i]);
                i++;
            }
        }
        
        [Test]
        public void Enumerable_TestSortByDescending()
        {
            IEnumerable<string> array = new[] { "12", "0", "25", "135" };
            string[] expected = {"0", "12", "25", "135" };
            Array.Reverse(expected);
            int i = 0;
            foreach (var number in array.SortByDescending(x => x.Length))
            {
                Assert.AreEqual(number, expected[i]);
                i++;
            }
        }
        
        [Test]
        public void Enumerable_TestSortByWithComparer()
        {
            SetUpList();
            var i = 0;
            foreach (var number in students.SortBy(x => x.Name.Length, Comparer<int>.Default))
            {
                Assert.GreaterOrEqual(number.Name.Length, i);
                i = number.Name.Length;
            }
        }
        
        [Test]
        public void Enumerable_TestSortDescendingByWithComparer()
        {
            SetUpList();
            var i = 100;
            foreach (var number in students.SortByDescending(x => x.Name.Length, Comparer<int>.Default))
            {
                Assert.GreaterOrEqual(i, number.Name.Length);
                i = number.Name.Length;
            }
        }
    }
}