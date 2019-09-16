
namespace Task1
{
    public class WithStartStepFinishIndex : IIndexCriterion
    {
        private readonly int _start;
        private readonly int _finish;
        private readonly int _step;

        public WithStartStepFinishIndex(int start, int finish, int step)
        {
            _finish = finish;
            _start = start;
            _step = step;
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
