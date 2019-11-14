using Bll.Contract;
using Bll.Contract.Storages;

namespace Bll.Implementation2
{
    public class FileService : IDocumentService
    {
        private readonly XDocStorage _xDocStorage;
        private readonly ICsvFileReader _fileReader;
        private readonly IXDocSerializer _xDocSerializer;
        private readonly IUrlParser _parser;

        public FileService(XDocStorage xDocStorage, IXDocSerializer xDocSerializer, ICsvFileReader fileReader, IUrlParser parser)
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