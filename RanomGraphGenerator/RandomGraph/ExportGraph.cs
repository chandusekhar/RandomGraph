using System.Collections.Generic;

namespace RandomGraph
{
    public interface ExportGraph
    {
        void ExportGraph(Dictionary<Vertex, List<Edge>> graph);
    }
}
