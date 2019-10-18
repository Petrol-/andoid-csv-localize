using System.Collections.Generic;

namespace AndroidCSVLocalize.Core
{
    public class LocaleRes
    {
        public int CsvIndex { get; set; }
        public string DirectoryName { get; }
        public IList<LocalizedValue> Resources { get; set; } = new List<LocalizedValue>();

        public LocaleRes(string directoryName)
        {
            DirectoryName = directoryName;
        }
    }
}