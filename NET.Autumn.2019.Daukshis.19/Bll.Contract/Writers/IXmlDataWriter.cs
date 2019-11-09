using System.Xml;

namespace Bll.Contract
{
    public interface IXmlDataWriter
    {
        void SaveData(XmlDocument data);
    }
}