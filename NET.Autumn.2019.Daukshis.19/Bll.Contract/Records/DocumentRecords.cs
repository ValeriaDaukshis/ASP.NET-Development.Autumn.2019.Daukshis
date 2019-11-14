using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Bll.Contract.Records
{
    [XmlRoot("urlAddresses")]
    public class DocumentRecords
    {
        public DocumentRecords()
        {
            this.Record = new List<Record>();
        }
        
        public DocumentRecords(Record[] records)
        {
            this.Record = records.ToList();
        }
        
        [XmlElement("urlAddress")]
        public List<Record> Record { get; private set; }
    }
}