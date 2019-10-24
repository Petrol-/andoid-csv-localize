using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AndroidCSVLocalize.Core
{
    public class JsonMailWriter : IResourceWriter
    {
        public void WriteResources(IList<LocaleRes> resources, string outDirectory)
        {
            foreach (var resource in resources)
            {
                HandleResource(resource, outDirectory);
            }
        }

        public void HandleResource(LocaleRes res, string outDir)
        {
            //1 create file
            var filePath = GetFilePath(outDir, GenerateFileName(res.DirectoryName));
            using (var sw = new StreamWriter(CreateFile(filePath)))
            {
                sw.WriteLine("{");
                sw.WriteLine(GenerateFileContent(res.Resources));
                sw.WriteLine("}");
                sw.Flush();
            }
        }

        public string GenerateFileContent(IList<LocalizedValue> values)
        {
            return string.Join(",\n", FormatLocalValues(values));
        }
        public IEnumerable<string> FormatLocalValues(IList<LocalizedValue> values)
        {
            return values.Select(FormatValue);
        }

        public string FormatValue(LocalizedValue value)
        {
            return $"\"{value.Key}\": \"{value.Value}\"";
        }
        private FileStream CreateFile(string filePath)
        {
            return File.Create(filePath);
        }
        public string GenerateFileName(string name)
        {
            return $"mailJson_{name}.json";
        }

        private string GetFilePath(string outDir, string fileName)
        {
            return Path.Combine(outDir, fileName);
        }
    }
}