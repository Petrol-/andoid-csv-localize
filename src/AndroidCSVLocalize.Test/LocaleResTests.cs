using NUnit.Framework;
using AndroidCSVLocalize.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidCSVLocalize.Core.Tests
{
    [TestFixture()]
    public class LocaleResTests
    {
        [Test]
        public void LocaleResTest_Expect_DirectoryName_Equals_Toto()
        {
           var localeres = new LocaleRes("toto");
           Assert.AreEqual("toto", localeres.DirectoryName);
        }

        [Test]
        public void LocaleResTest_Expect_DefaultResources_NotNull()
        {
            var localeres = new LocaleRes(null);

            Assert.IsNotNull(localeres.Resources);
        }

        [Test]
        public void LocaleResTest_SetResources_Expect_SameInstance()
        {
            var res = new List<LocalizedValue>();
            var localeRes = new LocaleRes(null)
            {
                Resources = res
            };

            Assert.AreSame(res, localeRes.Resources);
        }
    }
}