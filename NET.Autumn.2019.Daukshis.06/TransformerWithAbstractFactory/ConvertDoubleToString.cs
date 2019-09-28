namespace TransformerWithAbstractFactory
{
    public class ConvertDoubleToString : TransformerFactory
    {
        public override TransformationMethod ToStringMethod()
        {
            return new DoubleToStringConverter();
        }
    }
}