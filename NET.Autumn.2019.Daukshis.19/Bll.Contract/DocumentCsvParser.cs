using System;
using System.Collections.Generic;
using Bll.Contract;

namespace Bll.Implementation1
{
    public class DocumentCsvParser : IUrlParser
    {
        public DocumentRecord[] ParseUrl(string[] url)
        {
            List<DocumentRecord> records = new List<DocumentRecord>();
            foreach (var value in url)
            {
                records.Add(ReadUrl(new Uri(value)));
            }

            return records.ToArray();
        }

        private DocumentRecord ReadUrl(Uri uri)
        {
            DocumentRecord record = new DocumentRecord();
            record.HostName = uri.Host;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (uri.Query.Length > 0)
            {
                foreach (string item in uri.Query.Split('&'))
                {
                    string[] parts = item.Substring(1, item.Length - 1).Split('=');
                    parameters.Add(parts[0], parts[1]);
                }

                record.Parameters = parameters;
            }

            string[] segment = uri.Segments;
            record.Segment = CorrectSegments(segment);

            return record;
        }

        private string[] CorrectSegments(string[] segments)
        {
            List<string> segment = new List<string>();
            foreach (var value in segments)
            {
                var segm = value.Replace("/", "");
                if (segm != string.Empty)
                {
                    segment.Add(segm);
                }
            }

            return segment.ToArray();
        }
    }
}