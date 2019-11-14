using Bll.Contract;
using Bll.Contract.Records;
using Bll.Contract.Serializers;

namespace Bll.Implementation
{
    public class FileService : IDocumentService
    {
        private readonly IFileReader _storage;
        private readonly ICsvFileReader _fileReader;
        private readonly IXmlSerializer _serializer;
        private readonly IUrlRecordParser _parser;

        public FileService(IFileReader storage, IXmlSerializer serializer, ICsvFileReader fileReader, IUrlRecordParser parser)
        {
            this._storage = storage;
            this._fileReader = fileReader;
            this._parser = parser;
            this._serializer = serializer;
        }

        public void Run()
        {
            string simpleDocumentAsXml = _storage.GetData();
            var simpleDocument = _fileReader.Deserialize(simpleDocumentAsXml);
            var parsed = _parser.ParseUrl(simpleDocument);
            DocumentRecords records = new DocumentRecords(parsed);
            _serializer.Serialize(records);
        }
    }
}