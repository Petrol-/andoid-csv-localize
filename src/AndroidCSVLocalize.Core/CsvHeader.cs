using System.Collections.Generic;

namespace AndroidCSVLocalize.Core
{
    public class CsvHeader
    {
        public const int KeyIndex = 1;
        public Dictionary<int, string> LocaleMapping { get; set; } = new Dictionary<int, string>();
    }
}