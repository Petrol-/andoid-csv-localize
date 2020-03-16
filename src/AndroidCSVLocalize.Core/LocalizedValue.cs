namespace AndroidCSVLocalize.Core
{
    public class LocalizedValue
    {
        public string Key { get; }
        public string Value { get; }

        public LocalizedValue(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}