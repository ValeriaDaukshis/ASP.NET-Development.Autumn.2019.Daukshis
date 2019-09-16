
namespace Task1
{
    public class WithStartStepIndex : IIndexCriterion
    {
        private readonly int _start;
        private readonly int _finish;
        private readonly int _step;

        public WithStartStepIndex(int[] array, int start, int step)
        {
            _start = start;
            _step = step;
            _finish = array.Length;
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
