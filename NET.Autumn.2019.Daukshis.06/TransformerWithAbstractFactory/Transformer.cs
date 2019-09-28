namespace TransformerWithAbstractFactory
{
    public class Transformer
    {
        private readonly DoubleDictionary _dictionary;
        public Transformer(TransformToEnglish transform)
        {
            _dictionary = transform.TransformToString();
        }

        public string Transform(double value)
        {
            return _dictionary.ValueDictionary(value);
        }
    }
}