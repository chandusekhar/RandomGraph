using System.Collections.Generic;
using System.Diagnostics;

namespace RandomGraph
{
    public class ErodsRenyiModel
    {
        private readonly int _numberOfVertices;
        private readonly int? _numberOfEdges;
        private readonly double? _edgeProbability;

        /// <summary>
        /// The Erdős–Rényi (or Edgar Gilbert) model for generating random grphs.
        /// In the G(V, p) model, a graph is constructed by connecting nodes randomly. 
        /// Each edge is included in the graph with probability p independent from every other edge.
        /// </summary>
        /// <param name="numberOfVertices">The number of vertices.</param>
        /// <param name="edgeProbability">The probability by wich an edge is included in the graph.</param>
        public ErodsRenyiModel(int numberOfVertices, double edgeProbability)
        {
            _numberOfVertices = numberOfVertices;
            _edgeProbability = edgeProbability;
        }

        /// <summary>
        /// The Erdős–Rényi (or  Edgar Gilbert) model for generating random grphs.
        /// In the G(V, E) model, a graph is chosen uniformly at random from 
        /// the collection of all graphs which have V nodes and E edges.
        /// </summary>
        /// <param name="numberOfVertices">The number of vertices.</param>
        /// <param name="numberOfEdges">The number od edges.</param>
        public ErodsRenyiModel(int numberOfVertices, int numberOfEdges)
        {
            _numberOfVertices = numberOfVertices;
            _numberOfEdges = numberOfEdges;
        }

        public Dictionary<Vertex, List<Edge>> GenerateGraph()
        {
            Dictionary<Vertex, List<Edge>> graph;

            if (_edgeProbability == null)
            {
                graph = GetGraphByVertexAndEdges();
            }
            else
            {
                graph = GetGraphByVerticesAndProbability();
            }

            return graph;
        }

        private Dictionary<Vertex, List<Edge>> GetGraphByVerticesAndProbability()
        {
            var graph = new Dictionary<Vertex, List<Edge>>();



            return graph;
        }

        private Dictionary<Vertex, List<Edge>> GetGraphByVertexAndEdges()
        {
            var graph = new Dictionary<Vertex, List<Edge>>();



            return graph;
        }
    }
}
