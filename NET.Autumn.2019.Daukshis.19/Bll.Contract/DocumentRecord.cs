using System.Collections.Generic;

namespace Bll.Contract
{
    public class DocumentRecord
    {
        public DocumentRecord(string hostName, string[] segment, Dictionary<string, string> parameters)
        {
            HostName = hostName;
            Segment = segment;
            Parameters = parameters;
        }

        public DocumentRecord()
        {
        }
        
        public string HostName { get; set; }
        public string[] Segment { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}