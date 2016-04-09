using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGraph
{
    public class D3JSONFileExport : IExportGraph
    {
        private readonly IDataWriter _dataWriter;

        public D3JSONFileExport(IDataWriter dataWriter)
        {
            _dataWriter = dataWriter;
        }

        public void ExportGraph(Dictionary<Vertex, List<Edge>> graph)
        {
            var sb = new StringBuilder(64);
            sb.Append("'nodes':[");
            var nodes = string.Join(",", graph.Keys.Select(vertex => "{'name':'" + (vertex.ID + 1) + "','group':1}"));
            sb.Append(nodes);

            sb.Append("],'links':[");

            var edges = new List<string>();
            foreach (var pair in graph)
            {
                foreach (var edge in pair.Value)
                {
                    edges.Add("{'source':" + pair.Key.ID + ",'target':" + edge.VertexID + ",'value':1}");
                }
            }

            var links = string.Join(",", edges);
            sb.Append(links);

            sb.Append("]");
            _dataWriter.WriteData(sb.ToString());
        }
    }
}