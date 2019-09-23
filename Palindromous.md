public static Boolean IsPalindrome(int array, int i, int count)
        {
            if (count == 0)
                return true;
            if (array.ToString()[i] == array.ToString()[array.ToString().Length - 1 - i] & count > 0)
            {
                count--;
                return IsPalindrome(array, i + 1, count);
            }
            return false;
        }