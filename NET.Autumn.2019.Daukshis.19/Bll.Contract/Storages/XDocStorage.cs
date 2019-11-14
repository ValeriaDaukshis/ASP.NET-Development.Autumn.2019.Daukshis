using System.Xml.Linq;
using Bll.Contract.Writers;

namespace Bll.Contract.Storages
{
    public abstract class XDocStorage : IXDocumentWriter, IFileReader
    {
        public abstract string GetData();

        public abstract void SaveData(XDocument data);
    }
}