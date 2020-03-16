using NUnit.Framework;
using AndroidCSVLocalize.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidCSVLocalize.Core.Tests
{
    [TestFixture()]
    public class LocalizedValueTests
    {
        [Test()]
        public void LocalizedValue_Expect_Key_Equals_Toto()
        {
            var localValue = new LocalizedValue("toto", null);
            Assert.AreEqual("toto",localValue.Key);
        }

        [Test()]
        public void LocalizedValue_Expect_Value_Equals_Toto()
        {
            var localValue = new LocalizedValue(null, "toto");
            Assert.AreEqual("toto", localValue.Value);
        }
    }
}