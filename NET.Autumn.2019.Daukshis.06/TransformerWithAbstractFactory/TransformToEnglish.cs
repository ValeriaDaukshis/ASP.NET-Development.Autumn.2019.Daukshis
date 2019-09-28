namespace TransformerWithAbstractFactory
{
    public class TransformToEnglish : TransformerFactory
    {
        public override DoubleDictionary TransformToString()
        {
            return new Dictionary();
        }
    }
}