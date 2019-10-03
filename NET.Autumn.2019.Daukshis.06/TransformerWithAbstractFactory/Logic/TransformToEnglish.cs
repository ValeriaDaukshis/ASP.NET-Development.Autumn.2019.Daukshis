using TransformerWithAbstractFactory.AbstractClasses;
using TransformerWithAbstractFactory.Dictionaries;

namespace TransformerWithAbstractFactory.Logic
{
    public class TransformToEnglish : TransformerFactory
    {
        public override TransformationMethod WordNotationMethod()
        {
            return new EnglishDictionary(new EnglishComplexDoubleValues(), new EnglishSimpleDoubleValues());
        }
    }
    
    public class TransformToRussian : TransformerFactory
    {
        public override TransformationMethod WordNotationMethod()
        {
            return new RussianDictionary(new RussianComplexDoubleValues(), new RussianSimpleDoubleValues());
        }
    }
}