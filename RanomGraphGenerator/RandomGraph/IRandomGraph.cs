using System.Collections.Generic;

namespace RandomGraph
{
    public interface IRandomGraph
    {
        Dictionary<Vertex, List<Edge>> GenerateGraph();
    }
}
