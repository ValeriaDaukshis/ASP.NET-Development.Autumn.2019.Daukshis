using System.Collections.Generic;

namespace Filter.Interfaces
{
    /// <summary>
    /// Double Simple Dictionary
    /// </summary>
    public interface IDoubleSimpleDictionary
    {
        Dictionary<char, string> GetSimpleDictionary();
    }

    /// <summary>
    /// Double Complex Dictionary
    /// </summary>
    public interface IDoubleComplexDictionary
    {
        Dictionary<string, string> GetComplexDictionary();
    }
}