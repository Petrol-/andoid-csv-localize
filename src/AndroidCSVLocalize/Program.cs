using System;
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
                // Add other dependencies here ...
                .BuildServiceProvider()
                .GetService<Application>()
                .Run(args);
        }
    }
}
