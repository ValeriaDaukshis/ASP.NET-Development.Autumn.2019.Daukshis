using System.Xml.Linq;
using Bll.Contract;
using Moq;
using NUnit.Framework;

namespace Bll.Implementation1.Tests
{
    [TestFixture]
    public class SimpleDocumentServiceTests
    {
        private Mock<XDocStorage> _storageMock;

        private Mock<ICsvDeserializer> _deserializerMock;

        private Mock<IXDocSerializer> _serializeMock;
        
        private Mock<IUrlParser> _parserMock;

        private IDocumentService _documentService;

        [SetUp]
        public void Setup()
        {
            _storageMock = new Mock<XDocStorage>();

            _deserializerMock = new Mock<ICsvDeserializer>();

            _serializeMock = new Mock<IXDocSerializer>();
            
            _parserMock = new Mock<IUrlParser>();

            _documentService = new FileService(_storageMock.Object, _serializeMock.Object,_deserializerMock.Object, _parserMock.Object);
        }

        #region Behavior verification

        [Test]
        public void RunMockTest_BehaviorVerification()
        {
            _documentService.Run();

            _storageMock.Verify(s => s.GetData(), Times.Once);

            _storageMock.Verify(s => s.SaveData(It.IsAny<XDocument>()));

            _serializeMock.Verify(s => s.Serialize(It.IsAny<DocumentRecord[]>()));

            _deserializerMock.Verify(d => d.Deserialize(It.IsAny<string>()));
        }

        #endregion
    }
}