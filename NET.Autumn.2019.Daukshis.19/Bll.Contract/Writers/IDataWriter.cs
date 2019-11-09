using System.Xml.Linq;

namespace Bll.Contract
{
    public interface IDataWriter
    {
        void SaveData(XDocument data);
    }
}