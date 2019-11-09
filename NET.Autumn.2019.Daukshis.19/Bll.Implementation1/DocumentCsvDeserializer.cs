﻿using Bll.Contract;

namespace Bll.Implementation1
{
    public class DocumentCsvDeserializer : ICsvDeserializer
    {
        public string[] Deserialize(string path)
        {
            return path.Split("\r\n");
        }
    }
}