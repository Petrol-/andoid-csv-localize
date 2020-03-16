using System.Collections.Generic;
using System.IO;

namespace AndroidCSVLocalize.Core
{
    public class AndroidResourceWriter : IResourceWriter
    {

        public const string StringFileName = "strings.xml";
        public void WriteResources(IList<LocaleRes> resources, string outDirectory)
        {
            foreach (var res in resources)
            {
                WriteLocalRes(res, outDirectory);
            }
        }

        private void WriteLocalRes(LocaleRes res, string outDir)
        {
            var path = CreateDirectory(outDir, res.DirectoryName);
            using (var sw = new StreamWriter(CreateStringFile(path)))
            {
                WriteFileStart(sw);
                WriteAllStrings(res.Resources, sw);
                WriteFileEnd(sw);
                sw.Flush();
            }
        }

        private string CreateDirectory(string baseDir, string directoryName)
        {
            var path = Path.Combine(baseDir, directoryName);
            Directory.CreateDirectory(path);
            return path;
        }

        private FileStream CreateStringFile(string path)
        {
            return File.Create(Path.Combine(path, StringFileName));
        }

        public void WriteFileStart(StreamWriter sw)
        {
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sw.WriteLine("<resources>");
        }

        private void WriteAllStrings(IList<LocalizedValue> values, StreamWriter sw)
        {
            foreach (var value in values)
            {
                WriteString(value, sw);
            }
        }

        public void WriteString(LocalizedValue value, StreamWriter sw)
        {
            sw.WriteLine($"<string name=\"{value.Key}\">{ReplaceSpecialChar(value.Value)}</string>");
        }

        public string ReplaceSpecialChar(string value)
        {
            return value?.Replace("&", "&#38;");
        }
        public void WriteFileEnd(StreamWriter sw)
        {
            sw.WriteLine("</resources>");

        }
    }
}