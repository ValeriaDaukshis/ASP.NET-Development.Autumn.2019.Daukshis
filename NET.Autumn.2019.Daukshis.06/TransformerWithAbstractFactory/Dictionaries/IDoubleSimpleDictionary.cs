using System.Collections.Generic;

namespace TransformerWithAbstractFactory.Dictionaries
{
    public interface IDoubleSimpleDictionary
    {
        Dictionary<char, string> GetSimpleDictionary();
    }
    
    public interface IDoubleComplexDictionary
    {
        Dictionary<double, string> GetComplexDictionary();
    }
}