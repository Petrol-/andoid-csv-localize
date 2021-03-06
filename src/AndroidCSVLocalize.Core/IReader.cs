﻿using System.Collections.Generic;
using System.IO;

namespace AndroidCSVLocalize.Core
{
    public interface IReader
    {
        IList<LocaleRes> Parse(StreamReader sr);
        IList<LocaleRes> ParseFile(string filePath);
    }
}