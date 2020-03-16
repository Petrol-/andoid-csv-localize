using System;
using AndroidCSVLocalize;
using NUnit.Framework;

namespace AndroidCSVLocalize.Tests
{
    [TestFixture()]
    public class ArgumentParserTest
    {
        [Test]
        public void ArgumentParser_instanciate_null_expect_ok()
        {
            Assert.IsNotNull(new ArgumentParser(null));
        }

        [Test]
        public void Parse_Null_Expect_Exception()
        {
            Assert.Throws<ArgumentException>(()=>new ArgumentParser(null).Parse());
        }

        [Test]
        public void Parse_1_Arg_Expect_Exception()
        {
            Assert.Throws<ArgumentException>(() => new ArgumentParser(new []{"toto"}).Parse());
        }

        [Test]
        public void Parse_3_Arg_Expect_Exception()
        {
            Assert.Throws<ArgumentException>(() => new ArgumentParser(new[] { "toto", "tata", "titi" }).Parse());
        }

        [Test]
        public void Parse_2_Arg_Expect_Param_InFilePath_equals_toto()
        {
            var args = new[] {"toto", null};
            var parser = new ArgumentParser(args);

            var parsedParams = parser.Parse();

            Assert.AreEqual("toto", parsedParams.InFilePath);
        }

        [Test]
        public void Parse_2_Arg_Expect_Param_OutDirectory_equals_toto()
        {
            var args = new[] { null, "toto" };
            var parser = new ArgumentParser(args);

            var parsedParams = parser.Parse();

            Assert.AreEqual("toto", parsedParams.OutDirectory);
        }

    }
}

