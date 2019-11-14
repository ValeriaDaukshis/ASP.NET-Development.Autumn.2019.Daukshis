using System;
using System.IO;
using Bll.Contract;

namespace Bll.Implementation
{
    public class FileSystemStorage : IFileReader
    {
        private readonly string _sourceFilePath;
        private readonly string _destinationFilePath;

        public FileSystemStorage(string sourceFilePath, string destinationFilePath)
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

        public string GetData()
        {
            using var sourceStreamReader = new StreamReader(File.OpenRead(_sourceFilePath));
            return sourceStreamReader.ReadToEnd();
        }
    }
}