using System;

namespace Queue.Tests
{
    static class QueueTests
    {
        static void Main(string[] args)
        {
            QueueProject.Queue<int> a = new QueueProject.Queue<int>();
            a.Enqueue(5);
            a.Enqueue(15);
            a.Enqueue(25);
            a.Enqueue(35);
            a.Enqueue(45);
            a.Enqueue(55);
            a.Enqueue(65);
            a.Enqueue(75);
            a.Enqueue(85);
            
            foreach(var b in a)
            {
                Console.WriteLine(b);
            }

            Console.WriteLine();
            Console.WriteLine(a.Peek());
            Console.WriteLine(a.DeQueue());
            
            a.Enqueue(95);
            a.Enqueue(105);
            a.Enqueue(115);
            
            Console.WriteLine();
            foreach(var b in a)
            {
                Console.WriteLine(b);
                // a.Enqueue(0); // throw exception
            }
            
            var c = new QueueProject.Queue<object>();
            c.Enqueue(new object());
            bool k = c.Equals(c.Peek());
            Console.WriteLine(k);

            int[] array = {25, 16, 35, 18, 0};
            QueueProject.Queue<int> newQueue = new QueueProject.Queue<int>(array);
            foreach(var b in newQueue)
            {
                Console.WriteLine(b);
            }

        }
    }
}