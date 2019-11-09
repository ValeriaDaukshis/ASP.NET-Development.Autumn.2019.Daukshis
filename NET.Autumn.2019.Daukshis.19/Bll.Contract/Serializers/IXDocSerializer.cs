using System.Xml.Linq;

namespace Bll.Contract
{
    public interface IXDocSerializer
    {
        XDocument Serialize(DocumentRecord[] source);
    }
}