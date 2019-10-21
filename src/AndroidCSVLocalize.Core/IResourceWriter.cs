using System.Collections.Generic;

namespace AndroidCSVLocalize.Core
{
    public interface IResourceWriter
    {
        void WriteResources(IList<LocaleRes> resources, string outDirectory);
    }
}