using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;

namespace RandomGraph
{
    public class ParseDimacsGraph : ParseGraphBase
    {
        const int VertexWeight = 1;
        const int EdgeWeight = 1;

        private static ILog Log { get; } = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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

                    Vertex vertex = graph.Keys.FirstOrDefault(v => v.ID == vertexID);
                    if (vertex == null)
                    {
                        vertex = new Vertex(vertexID, VertexWeight);
                        graph.Add(vertex, new List<Edge>());
                        Log.Debug($"vertex: {vertexID}");
                    }
                    var edges = graph.Single(p => p.Key.ID == vertexID).Value;
                    if (edges.All(e => e.VertexID != connectedVertexID))
                    {
                        edges.Add(new Edge(connectedVertexID, EdgeWeight));
                        Log.Debug($"edge: {vertexID} {connectedVertexID}");
                    }

                    Vertex connectedVertex = graph.Keys.FirstOrDefault(v => v.ID == connectedVertexID);
                    if (connectedVertex== null)
                    {
                        connectedVertex = new Vertex(connectedVertexID, VertexWeight);
                        graph.Add(connectedVertex, new List<Edge>());
                        Log.Debug($"connectedVertexID: {connectedVertexID}");
                    }
                    var connectedEdges = graph.Single(p => p.Key.ID == connectedVertexID).Value;
                    if (connectedEdges.All(e => e.VertexID != vertexID))
                    {
                        connectedEdges.Add(new Edge(vertexID, EdgeWeight));
                        Log.Debug($"connectedEdges: {connectedVertexID} {vertexID}");
                    }
                }
            }

            // Order graph by vertex IDs.
            graph = graph.OrderBy(p => p.Key.ID).ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);

            return graph;
        }
    }
}
