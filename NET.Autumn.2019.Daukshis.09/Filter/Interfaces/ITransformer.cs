namespace Filter.Interfaces
{
    /// <summary>
    /// Transform double value to words
    /// </summary>
    public interface ITransformer<T, TV>
    {
        TV TransformToWord(T value);
    }
}