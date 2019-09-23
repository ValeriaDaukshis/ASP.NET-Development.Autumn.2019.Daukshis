namespace Filter
{
    public class FilterByPalindrome : IIndex
    {
        public bool IsMatch(int number)
        {
            string value = number.ToString();
            return IsPalindrome(value, 0, value.Length / 2);
        }
        public bool IsPalindrome(string value, int i, int count)
        {
            if (count == 0)
                return true;
            if (value[i] == value[value.Length - 1 - i] & count > 0)
            {
                count--;
                return IsPalindrome(value, i + 1, count);
            }
            return false;
        }
    }
}