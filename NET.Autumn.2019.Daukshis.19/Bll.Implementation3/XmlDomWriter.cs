using System;
using System.Xml;
using Bll.Contract;

namespace Bll.Implementation3
{
    public class XmlDomWriter
    {
        private XmlElement _urlAddresses;
        private XmlDocument _doc;

        public void WriteHeader()
        {
            _doc = new XmlDocument();
            _doc.AppendChild(_doc.CreateXmlDeclaration("1.0", null, "yes"));
            _urlAddresses = _doc.CreateElement("urlAddresses");
        }
        
        public void Write(DocumentRecord record)
        {
            if (record is null)
            {
                throw new ArgumentNullException($"{nameof(record)} is null");
            }
            XmlElement urlAddress = _doc.CreateElement("urlAddress");
            // host name
            XmlElement host = _doc.CreateElement("host");
            XmlAttribute name = _doc.CreateAttribute("name");
            name.Value = record.HostName;
            
            host.Attributes.Append(name);
            urlAddress.AppendChild(host);

            //segments
            WriteSegments(record, urlAddress);

            //parameters
            WriteParameters(record, urlAddress);

            _urlAddresses.AppendChild(urlAddress);
        }
        
        public XmlDocument WriteFooter()
        {
            _doc.AppendChild(_urlAddresses);
            return _doc;
        }

        private void WriteSegments(DocumentRecord record, XmlElement urlAddress)
        {
            if (record.Segment is null)
            {
                return;
            }
            
            XmlElement uri = _doc.CreateElement("uri");
            foreach (var segment in record.Segment)
            {
                XmlElement segments = _doc.CreateElement("segment");
                segments.AppendChild(_doc.CreateTextNode(segment));
                uri.AppendChild(segments);
            }

            urlAddress.AppendChild(uri);
        }

        private void WriteParameters(DocumentRecord record, XmlElement urlAddress)
        {
            if (record.Parameters is null)
            {
                return;
            }
            XmlElement parameters = _doc.CreateElement("parameters");
            foreach (var parameter in record.Parameters)
            {
                XmlElement segments = _doc.CreateElement("parameter");
                XmlAttribute value = _doc.CreateAttribute("value");
                value.Value = parameter.Value;
                XmlAttribute key = _doc.CreateAttribute("key");
                key.Value = parameter.Key;
                segments.Attributes.Append(value);
                segments.Attributes.Append(key);
                parameters.AppendChild(segments);
            }

            urlAddress.AppendChild(parameters);
        }
    }
}