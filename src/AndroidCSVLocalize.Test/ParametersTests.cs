using NUnit.Framework;
using AndroidCSVLocalize.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidCSVLocalize.Core.Tests
{
    [TestFixture()]
    public class ParametersTests
    {
        [Test()]
        public void ParametersTest()
        {
           Assert.IsNotNull(new Parameters(null,null));
        }

    }
}