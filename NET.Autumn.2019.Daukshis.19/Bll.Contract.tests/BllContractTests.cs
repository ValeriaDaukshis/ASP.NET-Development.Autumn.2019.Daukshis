using System.Xml.Linq;
using Moq;
using NUnit.Framework;

namespace Bll.Contract.tests
{
    public class BllContractTests
    {
        [Test]
        public void GetDataMockTest()
        {
            string expected = "Test string for reading.";
            
            var mockDataWriter = new Mock<IDataReader>();
            
            mockDataWriter.Setup(s => s.GetData()).Returns(expected);

            IDataReader dataWriter = mockDataWriter.Object;

            string actual = dataWriter.GetData();

            Assert.AreEqual(expected, actual);

            mockDataWriter.Verify();
        }
        
        [Test]
        public void SaveDataMockTest()
        {
            var mockDataWriter = new Mock<IDataWriter>();

            IDataWriter dataWriter = mockDataWriter.Object;

            dataWriter.SaveData(It.IsAny<XDocument>());

            mockDataWriter.Verify();
        }
        
        [Test]
        public void RunMockTest_BehaviorVerification()
        {
            var documentService = new Mock<IDocumentService>();
            
            documentService.Object.Run();
            
            documentService.Verify();
        }
    }
    
    [TestFixture]
    public class StorageTests
    {
        [Test]
        public void GetDataTests()
        {
            string expected = "Test string for reading.";

            var mockStorage = new Mock<XDocStorage>();
            
            mockStorage.Setup(s => s.GetData()).Returns(expected);

            string actual = mockStorage.Object.GetData();

            Assert.AreEqual(expected, actual);

            mockStorage.Verify();
        }
        
        [Test]
        public void SaveDataTests()
        {
            var mockStorage = new Mock<XDocStorage>();
            
            mockStorage.Setup(s => s.SaveData(It.IsAny<XDocument>()));

            XDocStorage storage = mockStorage.Object;

            storage.SaveData(It.IsAny<XDocument>());

            mockStorage.Verify();
        }
    }
}