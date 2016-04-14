using System.Collections.Generic;

namespace RandomGraph
{
    public abstract class ParseGraphBase
    {
        public IDataLoader DataLoader { get; set; }

        protected ParseGraphBase(IDataLoader dataLoader)
        {
            DataLoader = dataLoader;
        }

        public abstract Dictionary<Vertex, List<Edge>> ParseGraph();
    }
}
