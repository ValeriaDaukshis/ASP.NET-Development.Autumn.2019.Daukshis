
namespace Task1
{
    public class WithoutIndex : IIndexCriterion
    {
        private readonly int _start;
        private readonly int _finish;
        private readonly int _step;

        public WithoutIndex(int[] array)
        {
            _step = 1;
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
