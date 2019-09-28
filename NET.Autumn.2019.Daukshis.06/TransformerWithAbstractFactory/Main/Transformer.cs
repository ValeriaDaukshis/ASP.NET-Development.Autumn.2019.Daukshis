using TransformerWithAbstractFactory.AbstractClasses;

namespace TransformerWithAbstractFactory.Main
{
    public class Transformer
    {
        private readonly TransformationMethod _method;
        public Transformer(TransformerFactory transform)
        {
            _method = transform.ToStringMethod();
        }
                
        public string Transform(double value)
        {
            return _method.TransformToString(value);
        }
    }
}