using TransformerWithAbstractFactory.AbstractClasses;

namespace TransformerWithAbstractFactory.Logic
{
    public class TransformTo2Notation : TransformerFactory
    {
        public override TransformationMethod WordNotationMethod()
        {
            return new DoubleToStringConverter();
        }
    }
}