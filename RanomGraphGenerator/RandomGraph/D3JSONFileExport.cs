using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGraph
{
    public class D3JsonFileExport : IExportGraph
    {
        private readonly IDataWriter _dataWriter;

        public D3JsonFileExport(IDataWriter dataWriter)
        {
            _dataWriter = dataWriter;
        }

        public void ExportGraph(Dictionary<Vertex, List<Edge>> graph)
        {
            var sb = new StringBuilder(128);
            sb.Append("{\"nodes\":[");
            var nodes = string.Join(",", graph.Keys.Select(vertex => "{\"name\":\"" + (vertex.ID + 1) + "\",\"group\":1}"));
            sb.Append(nodes);

            sb.Append("],\"links\":[");

            var edges = (from pair in graph from edge in pair.Value.DistinctBy(edge => edge.VertexID) select "{\"source\":" + pair.Key.ID + ",\"target\":" + edge.VertexID + ",\"value\":1}").ToList();

            var links = string.Join(",", edges);
            sb.Append(links);

            sb.Append("]");
            _dataWriter.WriteData(sb.ToString());
        }
    }
}