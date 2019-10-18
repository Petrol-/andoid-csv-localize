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
        private const char ColSeparator = ';';
        private const int KeyIndex = 0;
        private readonly ILogger<CsvReader> _logger;

        public CsvReader(ILogger<CsvReader> logger)
        {
            _logger = logger;
        }

        public IList<LocaleRes> Parse(string filePath)
        {
            ThrowOnInvalidFile(filePath);
            using (var sr = new StreamReader(filePath, Encoding.GetEncoding(1252)))
            {
                var header = ParseHeader(sr);

            }
            return null;
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
            return SplitLine(sr.ReadLine());
        }

        private string[] SplitLine(string line)
        {
            return line.Split(ColSeparator);
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
    }
}