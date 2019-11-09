using Bll.Contract;

namespace Bll.Implementation3
{
    public class FileService : IDocumentService
    {
        private readonly XmlDocStorage _xDocStorage;
        private readonly ICsvDeserializer _deserializer;
        private readonly IXmlDocSerializer _xDocSerializer;
        private readonly IUrlParser _parser;

        public FileService(XmlDocStorage xDocStorage, IXmlDocSerializer xDocSerializer, ICsvDeserializer deserializer, IUrlParser parser)
        {
            this._xDocStorage = xDocStorage;
            this._deserializer = deserializer;
            this._parser = parser;
            this._xDocSerializer = xDocSerializer;
        }

        public void Run()
        {
            string simpleDocumentAsXml = _xDocStorage.GetData();
            var simpleDocument = _deserializer.Deserialize(simpleDocumentAsXml);
            var parsed = _parser.ParseUrl(simpleDocument);
            var simpleDocumentAsJson = _xDocSerializer.Serialize(parsed);
            _xDocStorage.SaveData(simpleDocumentAsJson);
        }
    }
}