using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace AndroidCSVLocalize.Core
{
    public class CsvReader : IReader
    {
        private const char ColSeparator = '\t';
        private const int KeyIndex = 0;
        private readonly ILogger<CsvReader> _logger;

        public CsvReader(ILogger<CsvReader> logger)
        {
            _logger = logger;
        }

        public IList<LocaleRes> ParseFile(string filePath)
        {
            ThrowOnInvalidFile(filePath);
            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {
                return Parse(sr);
            }

        }
        public IList<LocaleRes> Parse(StreamReader sr)
        {
            var header = ParseHeader(sr);
            var resources = CreateLocaleResFromHeader(header);
            return ParseBody(resources, sr);
        }

        private void ThrowOnInvalidFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException($"{nameof(filePath)} is null or empty");

            if (!File.Exists(filePath))
                throw new ArgumentException($"{nameof(filePath)} does not exists");
        }

        private void GoToStreamStart(Stream stream)
        {
            stream.Position = 0;
        }

        private string[] ReadNextLine(TextReader sr)
        {
            var line = sr.ReadLine();
            return SplitLine(line);
        }

        private string[] SplitLine(string line)
        {
            return line?.Split(ColSeparator);
        }

        public CsvHeader ParseHeader(StreamReader sr)
        {
            GoToStreamStart(sr.BaseStream);
            var csvHeader = new CsvHeader();
            var headerStr = ReadNextLine(sr);
            for (var i = 1; i < headerStr.Length; i++)
            {
                csvHeader.LocaleMapping.Add(i, headerStr[i]);
            }
            return csvHeader;
        }

        public IList<LocaleRes> CreateLocaleResFromHeader(CsvHeader header)
        {
            return header.LocaleMapping.Select((keyValue) => new LocaleRes(keyValue.Value)
            {
                CsvIndex = keyValue.Key
            }).ToList();
        }

        public IList<LocaleRes> ParseBody(IList<LocaleRes> resources, StreamReader sr)
        {
            string[] line;
            var expectedSize = resources.Count + 1;
            while ((line = ReadNextLine(sr)) != null)
            {
                var key = GetKey(line);
                if (line.Length != expectedSize)
                {
                    _logger.LogError($"Malformed line for Key {key}. Line has {line.Length} elements but {expectedSize} are expected");
                    continue;
                }

                foreach (var res in resources)
                {
                    var value = GetValue(res.CsvIndex, line);
                    if (!string.IsNullOrEmpty(value))
                        res.Resources.Add(new LocalizedValue(key, value));
                }
            }
            return resources;
        }

        private string GetKey(string[] line)
        {
            return line[KeyIndex];
        }

        private string GetValue(int index, string[] values)
        {
            return values[index];
        }
    }
}