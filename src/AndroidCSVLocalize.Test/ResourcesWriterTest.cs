using System.ComponentModel.DataAnnotations;
using System.IO;
using AndroidCSVLocalize.Core;
using NUnit.Framework;

namespace AndroidCSVLocalize.Test
{
    [TestFixture]
    public class ResourcesWriterTest
    {
        [Test]
        public void ReplaceSpecialChar_GivenCharToReplace_Expect_Char_Replaced()
        {
            var writer = new ResourceWriter();

            Assert.AreEqual("&#38;", writer.ReplaceSpecialChar("&"));
        }

        //[Test]
        //public void WriteString_EXpect_Ok()
        //{
        //    var writer = new ResourceWriter();
        //    using (var ms = new MemoryStream())
        //    {
        //        writer.WriteFileStart(new StreamWriter(ms));
        //        ms.Flush();
        //        ms.Position = 0;
        //        var sr = new StreamReader(ms);
        //        var firstLine = sr.ReadLine();
        //        var secondLine = sr.ReadLine();

        //        Assert.AreEqual("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", firstLine);
        //        Assert.AreEqual("<resources>",secondLine);
        //    }


        //}

  
    }
}