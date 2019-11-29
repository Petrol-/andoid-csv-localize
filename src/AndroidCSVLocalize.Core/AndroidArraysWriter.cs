using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AndroidCSVLocalize.Core
{
    public class AndroidArraysWriter : IResourceWriter
    {
        public const string StringFileName = "arrays.xml";
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
                WriteArrays(res.Resources, sw);
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

        private void WriteArrays(IList<LocalizedValue> values, StreamWriter sw)
        {
            var groups = values.GroupBy(key => key.Key);

            foreach (var group in groups)
            {
                WriteArray(group, sw);
            }
        }

        public void WriteArray(IGrouping<string, LocalizedValue> array, StreamWriter sw)
        {
            //Write xml array begin
            //Write all items
            var arrayName = array.First().Key;
            WriteArrayStart(arrayName, sw);
            foreach (var item in array)
            {
                WriteItem(item, sw);
            }
            WriteArrayEnd(sw);
            //write xml array end
        }

        public void WriteArrayStart(string arrayName, StreamWriter sw)
        {
            sw.WriteLine($"<string-array name=\"{arrayName}\">");
        }

        public void WriteArrayEnd(StreamWriter sw)
        {
            sw.WriteLine($"</string-array>");
        }

        public void WriteItem(LocalizedValue value, StreamWriter sw)
        {
            sw.WriteLine($"<item>{ReplaceSpecialChar(value.Value)}</item>");
        }
        public string ReplaceSpecialChar(string value)
        {
            return value?.Replace("&", "&#38;");
        }
        public void WriteFileStart(StreamWriter sw)
        {
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sw.WriteLine("<resources>");
        }
        public void WriteFileEnd(StreamWriter sw)
        {
            sw.WriteLine("</resources>");

        }
    }
}