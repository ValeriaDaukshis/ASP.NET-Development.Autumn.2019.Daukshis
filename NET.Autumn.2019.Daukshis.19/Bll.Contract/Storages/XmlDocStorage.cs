using System.Xml;
using Bll.Contract.Writers;

namespace Bll.Contract.Storages
{
    public abstract class XmlDocStorage : IFileReader, IXmlDocumentWriter
    {
        public abstract string GetData();

        public abstract void SaveData(XmlDocument data);
    }
}