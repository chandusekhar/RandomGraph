using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGraph
{
    public class FullWeightedMetisFileExport : IExportGraph
    {
        private readonly IDataWriter _dataWriter;

        public FullWeightedMetisFileExport(IDataWriter dataWriter)
        {
            _dataWriter = dataWriter;
        }

        public void ExportGraph(Dictionary<Vertex, List<Edge>> graph)
        {
            var sb = new StringBuilder(128);

            sb.Append(graph.Keys.Count + " " + graph.Sum(v => v.Value.Count) + " 011");

            foreach (var pair in graph)
            {
                sb.Append($"{Environment.NewLine}{pair.Key.Weight} {string.Join(" ", pair.Value.Select(edge => $"{edge.VertexID} {edge.Weight}"))}");
            }

            _dataWriter.WriteData(sb.ToString());
        }
    }
}
