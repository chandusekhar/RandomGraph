using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGraph
{
    public class UnweightedMetisFileExport : IExportGraph
    {
        private readonly IDataWriter _dataWriter;

        public UnweightedMetisFileExport(IDataWriter dataWriter)
        {
            _dataWriter = dataWriter;
        }

        public void ExportGraph(Dictionary<Vertex, List<Edge>> graph)
        {
            var sb = new StringBuilder(128);

            var countOfEdges = graph.Sum(v => v.Value.Count);
            sb.Append(graph.Keys.Count + " " + countOfEdges/2);

            foreach (var pair in graph)
            {
                sb.Append($"{Environment.NewLine}{string.Join(" ", pair.Value.Select(edge => (edge.VertexID + 1).ToString()))}");
            }

            _dataWriter.WriteData(sb.ToString());
        }
    }
}
