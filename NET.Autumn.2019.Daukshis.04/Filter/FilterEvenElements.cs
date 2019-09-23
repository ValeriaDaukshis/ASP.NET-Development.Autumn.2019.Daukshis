namespace Filter
{
    public class FilterEvenElements : IIndex
    {
        public bool IsMatch(int value)
        {
            return value % 2 == 0 ? true : false;
        }
    }
}