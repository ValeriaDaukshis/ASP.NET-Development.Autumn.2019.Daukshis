using System;
using System.IO;
using Bll.Contract;
using DependencyResolver;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ResolverConfig().CreateServiceProvider();
            
            serviceProvider.GetService<IDocumentService>().Run();

            string targetFilePath = ResolverConfig.ConfigurationRoot["targetFilePath"];

            Console.WriteLine(new StreamReader(File.Open(targetFilePath, FileMode.Open)).ReadToEnd());
        }
    }
}