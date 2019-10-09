namespace Filter.Interfaces
{
    /// <summary>
    /// Transform double value to words
    /// </summary>
    public interface ITransformer<TSource, TResult>
    {
        TResult TransformToWord(TSource value);
    }
}