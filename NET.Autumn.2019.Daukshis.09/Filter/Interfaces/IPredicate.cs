namespace Filter.Interfaces
{
    /// <summary>
    /// Is value Predicate
    /// </summary>
    public interface IPredicate<TSource>
    {
        bool IsMatch<TSource>(TSource value);
    }
}