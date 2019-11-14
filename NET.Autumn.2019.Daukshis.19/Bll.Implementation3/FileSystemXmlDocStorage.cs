using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Bll.Contract;
using Bll.Contract.Storages;

namespace Bll.Implementation3
{
    public class FileSystemXmlDocStorage : XmlDocStorage
    {
        private readonly string _sourceFilePath;
        private readonly string _destinationFilePath;

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
            
            this._sourceFilePath = sourceFilePath;
            this._destinationFilePath = destinationFilePath;
        }
        
        public override string GetData()
        {
            using var sourceStreamReader = new StreamReader(File.OpenRead(_sourceFilePath));
            return sourceStreamReader.ReadToEnd();
        }

        public override void SaveData(XmlDocument data)
        {
            data.Save(_destinationFilePath);
        }
    }
}