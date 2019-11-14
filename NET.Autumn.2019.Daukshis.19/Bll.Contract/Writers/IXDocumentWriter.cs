using System.Xml.Linq;

namespace Bll.Contract.Writers
{
    public interface IXDocumentWriter
    {
        void SaveData(XDocument data);
    }
}