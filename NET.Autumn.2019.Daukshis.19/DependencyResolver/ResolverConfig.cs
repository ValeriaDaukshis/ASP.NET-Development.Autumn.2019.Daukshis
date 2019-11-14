using System;
using System.IO;
using Bll.Contract;
using Bll.Contract.Serializers;
using Bll.Implementation;
using Bll.Implementation1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DocumentCsvFileReader = Bll.Implementation.DocumentCsvFileReader;
using FileService = Bll.Implementation.FileService;

namespace DependencyResolver
{
    public class ResolverConfig
    {
        public static IConfigurationRoot ConfigurationRoot { get; } =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public IServiceProvider CreateServiceProvider()
        {
            string sourceFilePath = CreateValidPath("sourceFilePath") ??
                                    throw new ArgumentNullException("CreateValidPath(\"sourceFilePath\")");
            string targetFilePath = CreateValidPath("targetFilePath") ??
                                    throw new ArgumentNullException("CreateValidPath(\"targetFilePath\")");
            
            var a = new ServiceCollection()
                .AddSingleton<ICsvFileReader, DocumentCsvFileReader>()
                .AddTransient<IXmlSerializer>(s => new ImportToXml(new StreamWriter(File.OpenWrite(sourceFilePath))))
                .AddTransient<IFileReader>(s => new FileSystemStorage(sourceFilePath, targetFilePath))
                .AddTransient<IDocumentService, FileService>()
                .AddTransient<IUrlRecordParser, DocumentParser>()
                .AddSingleton<IDocumentLogger, Logger>()
                .BuildServiceProvider();
            return a;
            
            //            return new ServiceCollection()
//                .AddSingleton<ICsvDeserializer, DocumentCsvDeserializer>()
//                .AddTransient<IXDocSerializer, DocumentXmlSerializer>()
//                .AddTransient<XDocStorage>(s => new FileSystemXDocStorage(sourceFilePath, targetFilePath))
//                .AddTransient<IDocumentService, FileService>()
//                .AddTransient<IUrlParser, DocumentCsvParser>()
//                .AddSingleton<IDocumentLogger, Logger>()
//                .BuildServiceProvider();
        }

        private string CreateValidPath(string path) =>
            Path.Combine(Directory.GetCurrentDirectory(), ConfigurationRoot[path]);
    }
}