using System;

namespace Task1
{
    public class WithStepIndex : IIndexCriterion
    {
        private readonly int _start;
        private readonly int _finish;
        private readonly int _step;

        public WithStepIndex(int[] array, int step)
        {
            _step = step;
            _finish = array.Length;
            _start = 0;
        }

        public int GetStart()
        {
            return _start;
        }

        public int GetFinish()
        {
            return _finish;
        }

        public int GetStep()
        {
            return _step;
        }
    }
}
