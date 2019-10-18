using System;
using AndroidCSVLocalize.Core;
using Microsoft.Extensions.Logging;

namespace AndroidCSVLocalize
{
    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly IReader _reader;

        public Application(ILogger<Application> logger, IReader reader)
        {
            _logger = logger;
            _reader = reader;
        }
        public void Run(string[] args)
        {
            try
            {
                var parameters = ParseArguments(args);
                var localeRes = _reader.ParseFile(parameters.InFilePath);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Failed to parse args", ex);
            }
        }

        private Parameters ParseArguments(string[] args)
        {
            return new ArgumentParser(args).Parse();
        }
    }
}