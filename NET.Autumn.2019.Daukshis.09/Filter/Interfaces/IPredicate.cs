namespace Filter.Interfaces
{
    /// <summary>
    /// Is value Predicate
    /// </summary>
    public interface IPredicate<T>
    {
        bool IsMatch<T>(T value);
    }
}