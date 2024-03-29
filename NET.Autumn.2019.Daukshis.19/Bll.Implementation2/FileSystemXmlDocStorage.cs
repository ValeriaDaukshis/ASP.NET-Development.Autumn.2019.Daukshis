﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Bll.Contract;
using Bll.Contract.Storages;

namespace Bll.Implementation2
{
    public class FileSystemXmlDocStorage : XDocStorage
    {
        private readonly string _sourceFilPath;
        private readonly string _destinationFilPath;

        public FileSystemXmlDocStorage(string sourceFilePath, string destinationFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath))
            {
                throw new ArgumentException(nameof(sourceFilePath));
            }

            if (string.IsNullOrWhiteSpace(destinationFilePath))
            {
                throw new ArgumentException(nameof(destinationFilePath));
            }
            
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException(nameof(sourceFilePath));
            }
            
            this._sourceFilPath = sourceFilePath;
            this._destinationFilPath = destinationFilePath;
        }
        
        public override string GetData()
        {
            using var sourceStreamReader = new StreamReader(File.OpenRead(_sourceFilPath));
            return sourceStreamReader.ReadToEnd();
        }

        public override void SaveData(XDocument data)
        {
            data.Save(_destinationFilPath);
        }
    }
}