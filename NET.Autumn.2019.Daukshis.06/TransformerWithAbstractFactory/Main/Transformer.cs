using TransformerWithAbstractFactory.AbstractClasses;

namespace TransformerWithAbstractFactory.Main
{
    public class Transformer
    {
        private readonly TransformationMethod _method;
        public Transformer(TransformerFactory transform)
        {
            _method = transform.WordNotationMethod();
        }

        /// <summary>
        /// Transform
        /// </summary>
        /// <param name="value">double value</param>
        /// <returns>Transformed double value</returns>
        public string Transform(double value)
        {
            return _method.TransformToString(value);
        }
    }
}