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
                if (fileData[0] == "p")
                {
                    var numberOfVertices = int.Parse(fileData[2]);
                    for (var i = 0; i < numberOfVertices; i++)
                    {
                        graph.Add(new Vertex(i, VertexWeight), new List<Edge>());
                    }
                }
                else if (fileData[0] == "e")
                {
                    var vertexID = int.Parse(fileData[1]) - 1;
                    var connectedVertexID = int.Parse(fileData[2]) - 1;

                    var vertex = graph.Single(v => v.Key.ID == vertexID);
                    if (vertex.Value.All(e => e.VertexID != connectedVertexID))
                    {
                        vertex.Value.Add(new Edge(connectedVertexID, EdgeWeight));
                    }

                    var conectedVertex = graph.Single(v => v.Key.ID == connectedVertexID);
                    if (conectedVertex.Value.All(e => e.VertexID != vertexID))
                    {
                        conectedVertex.Value.Add(new Edge(vertexID, EdgeWeight));
                    }
                }
            }
            
            return graph;
        }
    }
}
