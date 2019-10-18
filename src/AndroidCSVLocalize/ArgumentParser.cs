using System;
using System.Collections.Generic;
using System.Text;
using AndroidCSVLocalize.Core;

namespace AndroidCSVLocalize
{
    public class ArgumentParser
    {
        private readonly string[] _args;

        public ArgumentParser(string[] args)
        {
            _args = args;
        }

        public Parameters Parse()
        {
            if (_args == null)
                throw new ArgumentException("args cannot be null");
            if (_args.Length != 2)
                throw new ArgumentException("args should have 2 arguments. The first arg is InFilePath. the second is outDirectory");

            return new Parameters(_args[0], _args[1]);
        }
    }
}
