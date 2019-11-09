using System.Xml;

namespace Bll.Contract
{
    public abstract class XmlDocStorage : IDataReader, IXmlDataWriter
    {
        public abstract string GetData();

        public abstract void SaveData(XmlDocument data);
    }
}