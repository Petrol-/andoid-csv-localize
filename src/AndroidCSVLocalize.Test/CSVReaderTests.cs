using NUnit.Framework;
using AndroidCSVLocalize.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;

namespace AndroidCSVLocalize.Core.Tests
{
    [TestFixture()]
    public class CsvReaderTests
    {
        private readonly ILogger<CsvReader> _loggerMock = new Mock<ILogger<CsvReader>>().Object;
        [Test()]
        public void CsvReaderTest()
        {
            Assert.DoesNotThrow(() => new CsvReader(new Mock<ILogger<CsvReader>>().Object));
        }
        [Test]
        public void Parse_Given_NullFilePath_Expect_ArgumentException()
        {
            var csvreader = new CsvReader(_loggerMock);

            Assert.Throws<ArgumentException>(() => csvreader.Parse(null));
        }
        [Test]
        public void Parse_Given_AFileThatDoesNotExists_Expect_ArgumentException()
        {
            var csvreader = new CsvReader(_loggerMock);
            Assert.Throws<ArgumentException>(() => csvreader.Parse("dfsdgjsjdgsd"));
        }

        [Test]
        public void ParseHeader_GivenStreamWith3Cols_Expect_2Locales()
        {
            var csvStr = "key;values;values-fr-rFR";
            CsvHeader csvHeader;
            using (var ms = CreateMemoryStreamWithLines(new List<string> { csvStr }))
            {
                var reader = new CsvReader(_loggerMock);
                using (var sr = new StreamReader(ms))
                    csvHeader = reader.ParseHeader(sr);
            }
            Assert.AreEqual(2, csvHeader.LocaleMapping.Count);
        }

        [Test]
        public void CreateLocaleResFromHeader_With_1_Header_Expect_1LocalRes()
        {
            var csvHeader = new CsvHeader();
            csvHeader.LocaleMapping.Add(1,"toto");
            var csvReader = new CsvReader(_loggerMock);

            var localeres = csvReader.CreateLocaleResFromHeader(csvHeader);

            Assert.AreEqual("toto",localeres.First().DirectoryName);

        }

        private MemoryStream CreateMemoryStreamWithLines(IList<string> lines)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            
            foreach (var line in lines)
            {
                sw.WriteLine(line);
            }
            sw.Flush();
            return ms;
        }
    }
}