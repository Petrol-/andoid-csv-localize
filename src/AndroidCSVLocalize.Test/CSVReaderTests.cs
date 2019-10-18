using NUnit.Framework;
using AndroidCSVLocalize.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;

namespace AndroidCSVLocalize.Core.Tests
{
    [TestFixture()]
    public class CsvReaderTests
    {
        [Test()]
        public void CsvReaderTest()
        {
            Assert.DoesNotThrow(() => new CsvReader(new Mock<ILogger<CsvReader>>().Object));
        }


    }
}