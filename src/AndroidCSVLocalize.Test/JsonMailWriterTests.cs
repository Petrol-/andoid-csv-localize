using NUnit.Framework;
using AndroidCSVLocalize.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidCSVLocalize.Core.Tests
{
    [TestFixture()]
    public class JsonMailWriterTests
    {

        [Test()]
        public void GenerateFileNameTest()
        {
            Assert.AreEqual("mailJson_TuTA.json", new JsonMailWriter().GenerateFileName("TuTA"));
        }

        [Test]
        public void FormatValue_Expect_Ok()
        {
            var localValue = new LocalizedValue("key1", "val1");
            Assert.AreEqual($"\"key1\": \"val1\"", new JsonMailWriter().FormatValue(localValue));
        }

        [Test]
        public void GenerateFileContent()
        {
            var localValues = new[] { new LocalizedValue("key1", "val1"), new LocalizedValue("key2", "val2"), };
            Assert.AreEqual("\"key1\": \"val1\",\n\"key2\": \"val2\"", new JsonMailWriter().GenerateFileContent(localValues));
        }
    }
}