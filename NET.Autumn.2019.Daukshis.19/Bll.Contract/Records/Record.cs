using System.Xml.Serialization;

namespace Bll.Contract.Records
{
    public class Record
    {
        [XmlElement("host")]
        public Names Name { get; set; }

        [XmlElement("uri")]
        public UriClass Segment { get; set; }
        
        [XmlElement("parameters")]
        public Parameters Parameters { get; set; }
    }
    
    public class Names
    {
        [XmlAttribute("name")]
        public string HostName { get; set; }
    }
    
    public class UriClass
    {
        [XmlElement("segment")]
        public string[] Segment { get; set; }
    }
    
    public class Parameters
    {
        [XmlAttribute("value")]
        public string[] Value { get; set; }
        
        [XmlAttribute("key")]
        public string[] Key { get; set; }
    }
}