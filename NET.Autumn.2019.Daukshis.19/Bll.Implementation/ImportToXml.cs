using System.IO;
using System.Xml.Serialization;
using Bll.Contract.Records;
using Bll.Contract.Serializers;

namespace Bll.Implementation
{
    public class ImportToXml : IXmlSerializer
    {
        private readonly string _path;
        public ImportToXml(string path)
        {
            this._path = path;
        }
        
        public void Serialize(DocumentRecords record)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(DocumentRecords));

            using (var writer = new StreamWriter(File.OpenWrite(_path)))
            {
                formatter.Serialize(writer, record);
            }
        }
    }
}