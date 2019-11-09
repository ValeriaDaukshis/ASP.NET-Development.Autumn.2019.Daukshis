using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Bll.Contract;

namespace Bll.Implementation1
{
    public class XmlFileWriter
    {
        private XmlWriter _xmlFileWriter;
        private XDocument doc;

        public void WriteHeader()
        {
            doc = new XDocument { Declaration = new XDeclaration("1.0", "UTF-8", "true") };
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            this._xmlFileWriter = doc.CreateWriter();
            this._xmlFileWriter.WriteStartElement("urlAddresses");
        }
        
        public void Write(DocumentRecord record)
        {
            if (record is null)
            {
                throw new ArgumentNullException($"{nameof(record)} is null");
            }

            this._xmlFileWriter.WriteStartElement("urlAddress");
                this._xmlFileWriter.WriteAttributeString("hostName", $"{record.HostName}");
                
                WriteSegments(record);
                
                WriteParameters(record);

            this._xmlFileWriter.WriteEndElement();
        }
        
        public XDocument WriteFooter()
        {
            this._xmlFileWriter.WriteEndElement();
            this._xmlFileWriter.Dispose();
            this._xmlFileWriter.Close();
            return doc;
        }

        private void WriteSegments(DocumentRecord record)
        {
            if (record.Segment is null)
            {
                return;
            }
            
            this._xmlFileWriter.WriteStartElement("uri");
            foreach (var segment in record.Segment)
            {
                this._xmlFileWriter.WriteElementString("segment", $"{segment}");
            }
            this._xmlFileWriter.WriteEndElement();
        }

        private void WriteParameters(DocumentRecord record)
        {
            if (record.Parameters is null)
            {
                return;
            }
            this._xmlFileWriter.WriteStartElement("parameter");
            
            foreach (var a in record.Parameters)
            {
                this._xmlFileWriter.WriteAttributeString("value", $"{a.Value}");
                this._xmlFileWriter.WriteAttributeString("key", $"{a.Key}");
            }
            
            this._xmlFileWriter.WriteEndElement();
        }
    }
}