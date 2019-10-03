using System.Collections.Generic;

namespace Filter.Interfaces
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