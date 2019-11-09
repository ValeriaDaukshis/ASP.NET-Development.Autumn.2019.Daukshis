using System.Xml;
using Bll.Contract;

namespace Bll.Implementation3
{
    public class DocumentXmlSerializer : IXmlDocSerializer
    {
        public XmlDocument Serialize(DocumentRecord[] records)
        {
            XmlDomWriter writeToFile = new XmlDomWriter();
            writeToFile.WriteHeader();
            foreach (var record in records)
            {
                writeToFile.Write(record);
            }

            return writeToFile.WriteFooter();
        }
    }
}