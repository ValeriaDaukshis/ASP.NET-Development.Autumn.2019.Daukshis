using System.Xml;

namespace Bll.Contract.Writers
{
    public interface IXmlDocumentWriter
    {
        void SaveData(XmlDocument data);
    }
}