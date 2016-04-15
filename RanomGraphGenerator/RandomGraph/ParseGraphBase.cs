using System.Collections.Generic;

namespace RandomGraph
{
    public abstract class ParseGraphBase
    {
        protected IDataLoader DataLoader { get; }

        protected ParseGraphBase(IDataLoader dataLoader)
        {
            DataLoader = dataLoader;
        }

        public abstract Dictionary<Vertex, List<Edge>> ParseGraph();
    }
}
