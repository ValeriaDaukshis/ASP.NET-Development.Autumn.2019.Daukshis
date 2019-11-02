using System;
using System.IO;
using System.Text;

namespace StreamDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=netcore-3.0
    // https://docs.microsoft.com/en-us/dotnet/api/system.io?view=netcore-3.0

    public static class StreamsExtension
    {
        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int countOfBytes = 0;
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open))
            
            using (FileStream destinationStream = new FileStream(destinationPath, FileMode.OpenOrCreate))
            {
                destinationStream.Position = 0;
                sourceStream.Position = 0;

                while (sourceStream.Position < sourceStream.Length)
                {
                    int symbol = sourceStream.ReadByte();
                    destinationStream.WriteByte((byte) symbol);
                    countOfBytes++;
                }
                
            }

            return countOfBytes;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            var UTF8 = new UTF8Encoding(true);
            
            string sourceFileData;
            using (StreamReader sourceReader = new StreamReader(sourcePath, UTF8))
            {
                sourceFileData = sourceReader.ReadToEnd();
            }
            
            byte[] buffer = UTF8.GetBytes(sourceFileData);
            
            MemoryStream memoryStream = new MemoryStream(buffer);

            byte[] buffer2 = memoryStream.ToArray();
            
            var sourceFileData2 = UTF8.GetString(buffer2);
            
            using (StreamWriter writer = new StreamWriter(destinationPath, true, UTF8))
            {
                writer.Write(sourceFileData2);
            }

            return sourceFileData2.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.
        
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int count = 0;
            int bufferSize = 1024;

            using (var sourceFile = new FileStream(sourcePath, FileMode.OpenOrCreate))
            using (var destinationFile = new FileStream(destinationPath, FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[bufferSize];
                int length;

                while ((length = sourceFile.Read(buffer, 0, bufferSize)) > 0)
                {
                    destinationFile.Write(buffer, 0, length);
                    count += length;
                }
            }

            return count;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.
        
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int count = 0;
            int bufferSize = 1024;

            using (var sourceFile = new FileStream(sourcePath, FileMode.OpenOrCreate))
            using (var destinationFile = new FileStream(destinationPath, FileMode.OpenOrCreate))
            {
                byte[] buffer = new byte[bufferSize];
                int length;

                while ((length = sourceFile.Read(buffer, 0, bufferSize)) > 0)
                {
                    MemoryStream memoryStream = new MemoryStream(buffer);
                    destinationFile.Write(memoryStream.ToArray(), 0, length);
                    count += length;
                }
            }

            return count;
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int readByte;
            int count = 0;
            using (var sourceFile = new FileStream(sourcePath, FileMode.OpenOrCreate))
            using (var destinationFile = new FileStream(destinationPath, FileMode.OpenOrCreate))
            using (BufferedStream bufferedStream = new BufferedStream(sourceFile, 2000))
            {
                while((readByte = bufferedStream.ReadByte()) > 0)
                {
                    destinationFile.WriteByte((byte)readByte);
                    count += readByte;
                }
            }

            return count;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            
            var UTF8 = new UTF8Encoding(true);
            int countOfLines = 0;
            using (StreamWriter destinationStream = new StreamWriter(destinationPath, true, UTF8)) 
            using (StreamReader sourceStream = new StreamReader(sourcePath, UTF8))
            {
                string line;
                while ((line = sourceStream.ReadLine()) != null)
                {
                    destinationStream.Write(line);
                    destinationStream.Write("\n");
                    countOfLines++;
                }
            }

            return countOfLines;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath is null)
            {
                throw new ArgumentNullException(nameof(sourcePath));
            }

            if (destinationPath == null)
            {
                throw new ArgumentNullException(nameof(destinationPath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException(
                    $"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }

//            if (!File.Exists(destinationPath))
//            {
//                try
//                {
//                    File.Create(destinationPath);
//                }
//                catch
//                {
//                    throw new FileNotFoundException(
//                        $"File '{destinationPath}' not found and can not be created. Parameter name: {nameof(destinationPath)}.");
//                }
//            }

//            if (new FileInfo(destinationPath).IsReadOnly)
//            {
//                throw new FieldAccessException(
//                    $"File '{destinationPath}' is readonly. Parameter name: {nameof(destinationPath)}.");
//            }
        }

        #endregion

        #endregion
    }
}