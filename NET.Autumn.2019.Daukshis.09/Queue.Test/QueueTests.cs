using System;
using NUnit.Framework;

namespace Queue.Test
{
    public class QueueTests
    {
        private QueueProject.Queue<int> _queue;
        private void Setup()
        {
            _queue = new QueueProject.Queue<int>();
            _queue.Enqueue(5);
            _queue.Enqueue(15);
            _queue.Enqueue(25);
            _queue.Enqueue(35);
            _queue.Enqueue(45);
            _queue.Enqueue(55);
            _queue.Enqueue(65);
            _queue.Enqueue(75);
            _queue.Enqueue(85);
        }

        [Test]
        public void CollectionExtensions_TestForeach()
        {
            Setup();
            int[] expected = { 5, 15, 25, 35, 45, 55, 65, 75, 85};
            int[] actual = new int[_queue.Count];
            var i = 0;
            foreach(var element in _queue)
            {
                actual[i] = element;
                ++i;
            }
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CollectionExtensions_TestConstructorWithIEnumerableParam()
        {
            int[] array = {25, 16, 35, 18, 0};
            QueueProject.Queue<int> newQueue = new QueueProject.Queue<int>(array);
            int[] actual = new int[newQueue.Count];
            var i = 0;
            foreach(var element in newQueue)
            {
                actual[i] = element;
                ++i;
            }

            Assert.AreEqual(array, actual);
        }
        
        [Test]
        public void CollectionExtensions_TestCopy()
        {
            int[] array = {25, 16, 35, 18, 0};
            QueueProject.Queue<int> newQueue = new QueueProject.Queue<int>(array);
            int[] actual = new int[array.Length];
            newQueue.CopyTo(actual, 0);
            Assert.AreEqual(array, actual);
        }
        
        [Test]
        public void CollectionExtensions_TestContains()
        {
            Setup();
            Assert.AreEqual(_queue.Contains(65), true);
        }
        
        [Test]
        public void CollectionExtensions_TestDeQueue()
        {
            Setup();
            _queue.DeQueue();
            int[] expected = { 15, 25, 35, 45, 55, 65, 75, 85};
            int[] actual = new int[_queue.Count];
            var i = 0;
            foreach(var element in _queue)
            {
                actual[i] = element;
                ++i;
            }
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CollectionExtensions_TestForeachWithEnqueue()
        {
            Assert.Throws<InvalidOperationException>(() =>
                {
                    foreach(var element in _queue)
                    {
                        _queue.Enqueue(85);
                    }
                });
        }
    }
}