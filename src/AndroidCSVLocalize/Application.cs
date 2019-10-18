using System;
using AndroidCSVLocalize.Core;
using Microsoft.Extensions.Logging;

namespace AndroidCSVLocalize
{
    public class Application
    {
        private readonly ILogger<Application> _logger;

        public Application(ILogger<Application> logger)
        {
            _logger = logger;
        }
        public void Run(string[] args)
        {
            try
            {
                var parameters = ParseArguments(args);

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