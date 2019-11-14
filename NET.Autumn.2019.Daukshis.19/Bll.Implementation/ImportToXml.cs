using System.IO;
using System.Xml.Serialization;
using Bll.Contract.Records;
using Bll.Contract.Serializers;

namespace Bll.Implementation
{
    public class ImportToXml : IXmlSerializer
    {
        private readonly StreamWriter _writer;
        public ImportToXml(StreamWriter writer)
        {
            this._writer = writer;
        }
        
        public void Serialize(DocumentRecords record)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(DocumentRecords));

            using (_writer)
            {
                formatter.Serialize(_writer, record);
            }
        }
    }
}