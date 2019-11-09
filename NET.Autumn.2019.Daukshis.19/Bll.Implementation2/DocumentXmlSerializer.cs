using System.Collections.Generic;
using System.Xml.Linq;
using Bll.Contract;

namespace Bll.Implementation2
{
    public class DocumentXmlSerializer : IXDocSerializer
    {
        public XDocument Serialize(DocumentRecord[] records)
        {
            XDomWriter writeToFile = new XDomWriter();
            List<XElement> elements = new List<XElement>();
            foreach (var record in records)
            {
                elements.Add(writeToFile.Write(record));
            }

            return writeToFile.CombineComponents(elements);
        }
    }
}