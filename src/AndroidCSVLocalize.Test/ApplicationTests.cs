using NUnit.Framework;
using AndroidCSVLocalize;
using System;
using System.Collections.Generic;
using System.Text;
using AndroidCSVLocalize.Core;
using Microsoft.Extensions.Logging;
using Moq;

namespace AndroidCSVLocalize.Tests
{
    [TestFixture]
    public class ApplicationTests
    {
        [Test]
        public void Run_Expect_NoException()
        {
            var loggerMock = new Mock<ILogger<Application>>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IResourceWriter>();
            var application = new Application(loggerMock.Object,readerMock.Object, writerMock.Object);
            var args = new[] { "toto", "toto" };

            Assert.DoesNotThrow(() => application.Run(args));
        }
    }
}