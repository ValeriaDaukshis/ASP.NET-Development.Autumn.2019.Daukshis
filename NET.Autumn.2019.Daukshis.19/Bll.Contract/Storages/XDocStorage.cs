using System.Xml.Linq;

namespace Bll.Contract
{
    public abstract class XDocStorage : IDataWriter, IDataReader
    {
        public abstract string GetData();

        public abstract void SaveData(XDocument data);
    }
}