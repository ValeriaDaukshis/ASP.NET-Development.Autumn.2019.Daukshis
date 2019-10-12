using NUnit.Framework;

namespace Task4.Tests
{
    public class Task4Tests
    {
        [TestCase(new int[] {0, 1, 2, 3, 4, 5}, 3, ExpectedResult = 1)]
        [TestCase(new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13}, 5, ExpectedResult = 11)]
        [TestCase(new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8}, 10, ExpectedResult = 8)]
        public int Test1(int[] array, int step)
            => MathExtensions.Circle(array, step);
    }
}