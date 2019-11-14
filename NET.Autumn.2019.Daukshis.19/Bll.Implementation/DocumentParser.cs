using System;
using System.Collections.Generic;
using System.Linq;
using Bll.Contract;
using Bll.Contract.Records;
using Uri = System.Uri;

namespace Bll.Implementation
{
    public class DocumentParser : IUrlRecordParser
    {
        private IDocumentLogger _logger;
        public DocumentParser(IDocumentLogger logger)
        {
            this._logger = logger;
        }

        public Record[] ParseUrl(string[] url)
        {
            List<Record> records = new List<Record>();
            try
            {
                foreach (var value in url)
                {
                    records.Add(ReadUrl(new Uri(value)));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "invalid format");
            }               
                    
            return records.ToArray();
        }

        private Record ReadUrl(Uri uri)
        {
            Record record = new Record();
            record.Name = new Names { HostName = uri.Host };
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (uri.Query.Length > 0)
            {
                foreach (string item in uri.Query.Split('&'))
                {
                    string[] parts = item.Substring(1, item.Length - 1).Split('=');
                    parameters.Add(parts[0], parts[1]);
                }

                var keys = parameters.Keys.ToArray();
                var values = parameters.Values.ToArray();
                record.Parameters = new Parameters { Key = keys, Value = values };
            }

            string[] segment = CorrectSegments(uri.Segments);
            record.Segment = new UriClass { Segment = segment };

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