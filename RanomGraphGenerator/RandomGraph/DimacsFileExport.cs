﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomGraph
{
    public class DimacsFileExport : IExportGraph
    {
        private readonly IDataWriter _dataWriter;

        public DimacsFileExport(IDataWriter dataWriter)
        {
            _dataWriter = dataWriter;
        }

        public void ExportGraph(Dictionary<Vertex, List<Edge>> graph)
        {
            var sb = new StringBuilder(GetComment());
            sb.Append(Environment.NewLine + GetProblemLine(graph));

            // The arc descriptors.
            foreach (var vertexEdgePair in graph)
            {
                sb.Append($"{Environment.NewLine}a {vertexEdgePair.Key.Weight}");
                foreach (var edge in vertexEdgePair.Value.DistinctBy(edge => edge.VertexID))
                {
                    sb.Append($" {edge.VertexID} {edge.Weight}");
                }
            }

            _dataWriter.WriteData(sb.ToString());
        }

        private string GetComment()
        {
            return "c Random generated graph.";
        }

        private string GetProblemLine(Dictionary<Vertex, List<Edge>> graph)
        {
            // The number of nodes in the network.
            var nodes = graph.Count;
            // The number of arcs in the network.
            var arcs = graph.SelectMany(x => x.Value).Count();

            return $"p edge {nodes} {arcs}";
        }
    }
}
