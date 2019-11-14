using Bll.Contract;
using Bll.Contract.Storages;

namespace Bll.Implementation3
{
    public class FileService : IDocumentService
    {
        private readonly XmlDocStorage _xDocStorage;
        private readonly ICsvFileReader _fileReader;
        private readonly IXmlDocSerializer _xDocSerializer;
        private readonly IUrlParser _parser;

        public FileService(XmlDocStorage xDocStorage, IXmlDocSerializer xDocSerializer, ICsvFileReader fileReader, IUrlParser parser)
        {
            this._xDocStorage = xDocStorage;
            this._fileReader = fileReader;
            this._parser = parser;
            this._xDocSerializer = xDocSerializer;
        }

        public void Run()
        {
            string simpleDocumentAsXml = _xDocStorage.GetData();
            var simpleDocument = _fileReader.Deserialize(simpleDocumentAsXml);
            var parsed = _parser.ParseUrl(simpleDocument);
            var simpleDocumentAsJson = _xDocSerializer.Serialize(parsed);
            _xDocStorage.SaveData(simpleDocumentAsJson);
        }
    }
}