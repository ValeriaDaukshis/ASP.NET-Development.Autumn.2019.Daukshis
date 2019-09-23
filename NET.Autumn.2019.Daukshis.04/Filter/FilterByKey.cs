namespace Filter
{
    public class FilterByKey : IIndex
    {
        private readonly int _key;
        public FilterByKey(int key)
        {
            _key = key;
        }

        public bool IsMatch(int number)
        {
            while (number > 0)
            {
                if (number % 10 == number)
                    return true;
                number /= 10;
            }

            return false;
        }
    }
}