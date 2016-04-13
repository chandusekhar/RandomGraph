using System.Collections.Generic;

namespace RandomGraph
{
    public interface IDataLoader
    {
        IEnumerable<string> LoadData();
    }
}
