using System;
using Algorithms.V4.StaticClasses;

namespace Adapter.Tests
{
    static class EntryPoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Euclidean with 2 params without timer: {GcdAlgorithms.FindGcdByEuclidean(555555, 30203)}");
            Console.WriteLine($"Euclidean with 2 params with timer: {GcdAlgorithms.FindGcdByEuclidean(out var milliseconds,555555, 30205)}, Time: {milliseconds}\n");
            
            Console.WriteLine($"Euclidean with 3 params without timer: {GcdAlgorithms.FindGcdByEuclidean(5, 10, 15)}"); 
            Console.WriteLine($"Euclidean with 3 params with timer: {GcdAlgorithms.FindGcdByEuclidean(out milliseconds,38262,252,154)}, Time: {milliseconds}\n");

            Console.WriteLine($"Euclidean with params without timer: {GcdAlgorithms.FindGcdByEuclidean(84, 168, 3598, 4568, 8562)}"); 
            Console.WriteLine($"Euclidean with params with timer: {GcdAlgorithms.FindGcdByEuclidean(out milliseconds,38262,252,154, 382654)}, Time: {milliseconds}\n");
            Console.ReadKey();
        }
    }
}