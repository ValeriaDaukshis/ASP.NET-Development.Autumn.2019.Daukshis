namespace Filter.Interfaces
{
    /// <summary>
    /// Is value Predicate
    /// </summary>
    public interface IPredicate
    {
        bool IsMatch(int value);
    }
}