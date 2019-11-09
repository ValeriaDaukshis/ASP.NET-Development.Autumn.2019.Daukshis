using System;
using System.IO;
using Bll.Contract;
using Bll.Implementation1;
using Bll.Implementation2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DocumentCsvDeserializer = Bll.Implementation1.DocumentCsvDeserializer;
using FileService = Bll.Implementation1.FileService;

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

            return new ServiceCollection()
                .AddSingleton<ICsvDeserializer, DocumentCsvDeserializer>()
                .AddTransient<IXDocSerializer, DocumentXmlSerializer>()
                .AddTransient<XDocStorage>(s => new FileSystemXDocStorage(sourceFilePath, targetFilePath))
                .AddTransient<IDocumentService, FileService>()
                .AddTransient<IUrlParser, DocumentCsvParser>()
                .BuildServiceProvider();
        }

        private string CreateValidPath(string path) =>
            Path.Combine(Directory.GetCurrentDirectory(), ConfigurationRoot[path]);
    }
}