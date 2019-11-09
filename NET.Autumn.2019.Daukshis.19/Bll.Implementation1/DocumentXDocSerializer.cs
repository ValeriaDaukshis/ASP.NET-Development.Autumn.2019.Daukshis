using System.Xml.Linq;
using Bll.Contract;

namespace Bll.Implementation1
{
    public class DocumentXDocSerializer : IXDocSerializer
    {
        public XDocument Serialize(DocumentRecord[] records)
        {
            XmlFileWriter writeToFile = new XmlFileWriter();
            writeToFile.WriteHeader();
            foreach (var record in records)
            {
                writeToFile.Write(record);
            }

            return writeToFile.WriteFooter();
        }
    }
}