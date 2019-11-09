using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Bll.Contract;

namespace Bll.Implementation2
{
    public class XDomWriter
    {
        public XElement Write(DocumentRecord record)
        {
            var element = new XElement("urlAddress",
            new XElement("host",
                new XAttribute("name", record.HostName)),
            record.Segment == null ? null :
                 new XElement("uri",
                from k in record.Segment
                select new XElement("segment", k)),
            record.Parameters == null ? null :
                 new XElement("parameters",
                from k in record.Parameters
                select new XAttribute("value", k.Value),
                from t in record.Parameters
                select new XAttribute("key", t.Key)));
        
                return element;
        }

        public XDocument CombineComponents(IEnumerable<XElement> elements)
        {
            var a = new XDocument(new XElement("urlAddresses",
                from n in elements
                select n));
            a.Save(@"C:\Users\dauks\ASP.NET\NET.Autumn.2019.Daukshis.19\ConsoleClient.aaa.xml");
            return a;
        }
    }
}