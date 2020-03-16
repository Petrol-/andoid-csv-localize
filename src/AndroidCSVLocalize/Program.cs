using System;
using AndroidCSVLocalize.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AndroidCSVLocalize
{
    class Program
    {
        static void Main(string[] args)
        {
            new ServiceCollection()
                .AddLogging(configure =>configure.AddConsole())
                .AddSingleton<Application>()
                .AddTransient<IReader, CsvReader>()
                .AddTransient<IResourceWriter, AndroidArraysWriter>()
                .BuildServiceProvider()
                .GetService<Application>()
                .Run(args);
        }
    }
}
