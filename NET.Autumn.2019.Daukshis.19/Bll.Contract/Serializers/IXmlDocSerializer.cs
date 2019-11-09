using System.Xml;

namespace Bll.Contract
{
    public interface IXmlDocSerializer
    {
        XmlDocument Serialize(DocumentRecord[] source);
    }
}