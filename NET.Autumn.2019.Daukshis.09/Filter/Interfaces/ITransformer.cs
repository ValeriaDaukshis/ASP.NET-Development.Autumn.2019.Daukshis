namespace Filter.Interfaces
{
    /// <summary>
    /// Transform double value to words
    /// </summary>
    public interface ITransformer
    {
        string TransformToWord<T>(T value) where T : struct;
    }
}