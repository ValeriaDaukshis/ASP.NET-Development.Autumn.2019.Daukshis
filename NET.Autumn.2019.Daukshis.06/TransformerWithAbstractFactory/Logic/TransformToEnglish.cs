using TransformerWithAbstractFactory.AbstractClasses;

namespace TransformerWithAbstractFactory.Logic
{
    public class TransformToEnglish : TransformerFactory
    {
        public override TransformationMethod ToStringMethod()
        {
            return new EnglishDictionary();
        }
    }
}