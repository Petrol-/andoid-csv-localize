using System;

namespace AndroidCSVLocalize.Core
{
    public class Parameters
    {
        public string InFilePath { get; }
        public string OutDirectory { get; }

        public Parameters(string inFilePath, string outDirectory)
        {
            InFilePath = inFilePath;
            OutDirectory = outDirectory;
        }
    }
}