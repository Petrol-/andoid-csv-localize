using Microsoft.Extensions.Logging;

namespace AndroidCSVLocalize.Core
{
    public class CsvReader
    {
        private readonly ILogger<CsvReader> _logger;

        public CsvReader(ILogger<CsvReader> logger)
        {
            _logger = logger;
        }
    }
}