using TransformerWithAbstractFactory.Dictionaries;

namespace TransformerWithAbstractFactory.AbstractClasses
{
    public abstract class TransformerFactory
    {
        public abstract TransformationMethod WordNotationMethod(IDoubleComplexDictionary complexDictionary, IDoubleSimpleDictionary simpleDictionary);
    }
}