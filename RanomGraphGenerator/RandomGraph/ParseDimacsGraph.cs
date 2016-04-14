using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomGraph
{
    public class ParseDimacsGraph : ParseGraphBase
    {
        const int VertexWeight = 1;
        const int EdgeWeight = 1;

        public ParseDimacsGraph(IDataLoader dataLoader) 
            : base(dataLoader)
        {
        }

        public override Dictionary<Vertex, List<Edge>> ParseGraph()
        {
            var graph = new Dictionary<Vertex, List<Edge>>();

            foreach (var line in DataLoader.LoadData())
            {
                var fileData = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (fileData[0] == "e")
                {
                    var vertexID = int.Parse(fileData[1]) - 1;
                    var connectedVertexID = int.Parse(fileData[2]) - 1;

                    Vertex? vertex = graph.Keys.FirstOrDefault(v => v.ID == vertexID);
                    if (vertex == null)
                    {
                        vertex = new Vertex(vertexID, VertexWeight);
                        graph.Add(vertex.Value, new List<Edge>());
                    }
                    else
                    {
                        Vertex? connectedVertex = graph.Keys.FirstOrDefault(v => v.ID == connectedVertexID);
                        if (!connectedVertex.HasValue)
                        {
                            connectedVertex = new Vertex(connectedVertexID, VertexWeight);
                            graph.Add(connectedVertex.Value, new List<Edge>());
                        }
                        graph.Single(p => p.Key.ID == connectedVertexID).Value.Add(new Edge(vertexID, EdgeWeight));
                    }
                }
            }

            return graph;
        }
    }
}
