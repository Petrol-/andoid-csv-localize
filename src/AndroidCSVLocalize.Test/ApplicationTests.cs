using NUnit.Framework;
using AndroidCSVLocalize;
using System;
using System.Collections.Generic;
using System.Text;
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
            var application = new Application(loggerMock.Object);
            var args = new[] { "toto", "toto" };

            Assert.DoesNotThrow(() => application.Run(args));
        }
    }
}