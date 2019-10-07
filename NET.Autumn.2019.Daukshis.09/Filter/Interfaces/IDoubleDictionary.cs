using System.Collections.Generic;

namespace Filter.Interfaces
{
    /// <summary>
    /// Double Simple Dictionary
    /// </summary>
    public interface IDoubleDictionary
    {
        Dictionary<char, string> SimpleDictionary { get; }
        Dictionary<string, string> ComplexDictionary { get; }
    }
}