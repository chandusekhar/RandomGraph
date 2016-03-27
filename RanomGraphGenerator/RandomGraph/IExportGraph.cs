using System.Collections.Generic;

namespace RandomGraph
{
    public interface IExportGraph
    {
        void ExportGraph(Dictionary<Vertex, List<Edge>> graph);
    }
}
