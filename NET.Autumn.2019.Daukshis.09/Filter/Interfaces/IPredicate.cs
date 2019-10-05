namespace Filter.Interfaces
{
    /// <summary>
    /// Is value Predicate
    /// </summary>
    public interface IPredicate
    {
        bool IsMatch<T>(T value)  where T : struct;
    }
}