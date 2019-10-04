namespace Filter.Interfaces
{
    /// <summary>
    /// Transform double value to words
    /// </summary>
    public interface ITransformer
    {
        string TransformToWord(double value);
    }
}